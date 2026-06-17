using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Restaurant.Data;
using Restaurant.Options;

namespace Restaurant.Tests;

public sealed class RestaurantWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly bool authenticated;
    private readonly string databaseName = Guid.NewGuid().ToString("N");

    public RestaurantWebApplicationFactory(bool authenticated)
    {
        this.authenticated = authenticated;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<ApplicationDbContext>));
            services.RemoveAll(typeof(ApplicationDbContext));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase(databaseName));

            services.PostConfigure<PaymentGatewayOptions>(options =>
            {
                options.Gateway = "Demo";
                options.Currency = "usd";
                options.ApplicationBaseUrl = "https://localhost";
            });

            if (authenticated)
            {
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = TestAuthHandler.SchemeName;
                    options.DefaultChallengeScheme = TestAuthHandler.SchemeName;
                }).AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(TestAuthHandler.SchemeName, _ => { });
            }
        });
    }

    public async Task SeedOrderAsync(int orderId)
    {
        using var scope = Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (await context.Orders.AnyAsync(order => order.Id == orderId))
        {
            return;
        }

        var category = new Data.Models.Category
        {
            Id = orderId + 1000,
            Name = "Integration Category",
            IconUrl = "https://example.com/category.jpg"
        };

        var product = new Data.Models.Product
        {
            Id = orderId + 2000,
            Name = "Integration Product",
            Description = "Integration description",
            Price = 25m,
            ImageUrl = "https://example.com/product.jpg",
            IsAvailable = true,
            CategoryId = category.Id,
            Category = category
        };

        var order = new Data.Models.Order
        {
            Id = orderId,
            Number = orderId + 600000,
            IdentityUserId = "user-1",
            Status = Data.Models.OrderStatus.InProgress,
            OrderTime = DateTime.UtcNow,
            TotalAmount = 25m
        };

        var orderItem = new Data.Models.OrderItem
        {
            Id = orderId + 3000,
            OrderId = order.Id,
            Order = order,
            ProductId = product.Id,
            Product = product,
            Quantity = 1
        };

        order.OrderItems.Add(orderItem);
        context.Categories.Add(category);
        context.Products.Add(product);
        context.Orders.Add(order);
        context.OrderItems.Add(orderItem);
        await context.SaveChangesAsync();
    }
}
