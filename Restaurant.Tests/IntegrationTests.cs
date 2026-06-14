using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Data;
using Restaurant.DTOs;
using Restaurant.Services;

namespace Restaurant.Tests;

public class IntegrationTests
{
    [Fact]
    public async Task Unauthenticated_OrderPage_RedirectsToLogin()
    {
        using var factory = new RestaurantWebApplicationFactory(authenticated: false);
        using var client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });

        var response = await client.GetAsync("/Order/GetAll");

        Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        Assert.Contains("/Identity/Account/Login", response.Headers.Location?.OriginalString, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task Authenticated_OrderPage_ReturnsSuccess()
    {
        using var factory = new RestaurantWebApplicationFactory(authenticated: true);
        using var client = factory.CreateClient();

        var response = await client.GetAsync("/Order/GetAll");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Authenticated_CheckoutPage_ForOwnedOrder_ReturnsSuccess()
    {
        using var factory = new RestaurantWebApplicationFactory(authenticated: true);
        await factory.SeedOrderAsync(7001);
        using var client = factory.CreateClient();

        var response = await client.GetAsync("/Checkout/Index?orderId=7001");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("Checkout", content, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task Authenticated_CheckoutSuccess_CompletesPendingPayment()
    {
        using var factory = new RestaurantWebApplicationFactory(authenticated: true);
        await factory.SeedOrderAsync(7002);

        using (var scope = factory.Services.CreateScope())
        {
            var checkoutService = scope.ServiceProvider.GetRequiredService<ICheckoutService>();
            await checkoutService.StartCheckoutAsync("user-1", new CheckoutDto
            {
                OrderId = 7002,
                FullName = "Integration User",
                Email = "integration@example.com",
                Address = "Integration Address"
            });
        }

        string sessionId;
        using (var scope = factory.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            sessionId = await context.Payments.Select(payment => payment.ProviderSessionId).SingleAsync();
        }

        using var client = factory.CreateClient();
        var response = await client.GetAsync($"/Checkout/Success?sessionId={sessionId}");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("payment was confirmed", content, StringComparison.OrdinalIgnoreCase);

        using var verificationScope = factory.Services.CreateScope();
        var verificationContext = verificationScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var order = await verificationContext.Orders.SingleAsync(orderItem => orderItem.Id == 7002);
        var payment = await verificationContext.Payments.SingleAsync();

        Assert.Equal(Restaurant.Data.Models.OrderStatus.Completed, order.Status);
        Assert.Equal(Restaurant.Data.Models.PaymentStatus.Completed, payment.Status);
    }
}
