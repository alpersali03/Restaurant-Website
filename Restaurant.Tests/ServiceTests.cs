using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.DTOs;
using Restaurant.Extensions;
using Restaurant.Options;
using Restaurant.Services;
using Restaurant.Services.Payments;

namespace Restaurant.Tests;

public class ServiceTests
{
    [Fact]
    public void ProductService_GetDetails_ReturnsProductWithCategory()
    {
        using var context = CreateContext();
        var category = new Category { Id = 101, Name = "Test Category", IconUrl = "https://example.com/category.jpg" };
        var product = new Product
        {
            Id = 201,
            Name = "Test Product",
            Description = "Desc",
            Price = 12.5m,
            ImageUrl = "https://example.com/product.jpg",
            IsAvailable = true,
            CategoryId = category.Id,
            Category = category
        };

        context.Categories.Add(category);
        context.Products.Add(product);
        context.SaveChanges();

        var service = new ProductService(context, CreateMapper());

        var result = service.GetDetails(product.Id);

        Assert.NotNull(result);
        Assert.Equal(product.Name, result!.Name);
        Assert.NotNull(result.Category);
        Assert.Equal(category.Name, result.Category!.Name);
    }

    [Fact]
    public void CategoryService_Delete_RemovesExistingCategory()
    {
        using var context = CreateContext();
        var category = new Category { Id = 301, Name = "Delete Me", IconUrl = "https://example.com/delete.jpg" };
        context.Categories.Add(category);
        context.SaveChanges();

        var service = new CategoryService(context, CreateMapper());

        service.Delete(category.Id);

        Assert.Null(context.Categories.FirstOrDefault(c => c.Id == category.Id));
    }

    [Fact]
    public void CategoryService_Delete_MissingCategory_Throws()
    {
        using var context = CreateContext();
        var service = new CategoryService(context, CreateMapper());

        Assert.Throws<ArgumentException>(() => service.Delete(999999));
    }

    [Fact]
    public async Task CheckoutService_StartAndConfirmCheckout_CreatesPendingPaymentAndCompletesOrder()
    {
        using var context = CreateContext();
        var order = CreateOrder(context, "user-1", orderId: 401, orderItemId: 501);
        var service = CreateCheckoutService(context);

        var redirectUrl = await service.StartCheckoutAsync("user-1", new CheckoutDto
        {
            OrderId = order.Id,
            FullName = "User One",
            Email = "user1@example.com",
            Address = "Address 1"
        });

        var payment = context.Payments.Single();
        var sessionId = payment.ProviderSessionId;

        Assert.Contains("/Checkout/Success?sessionId=", redirectUrl, StringComparison.OrdinalIgnoreCase);
        Assert.Equal(PaymentStatus.Pending, payment.Status);
        Assert.Equal("Demo", payment.Provider);

        var confirmed = await service.ConfirmPaymentAsync("user-1", sessionId);

        var checkout = context.Checkouts.Single();
        var updatedOrder = context.Orders.Single(o => o.Id == order.Id);
        var updatedPayment = context.Payments.Single();

        Assert.True(confirmed);
        Assert.Equal("User One", checkout.FullName);
        Assert.Equal(PaymentStatus.Completed, updatedPayment.Status);
        Assert.Equal(OrderStatus.Completed, updatedOrder.Status);
    }

    [Fact]
    public async Task CheckoutService_StartCheckout_RejectsDifferentUsersOrder()
    {
        using var context = CreateContext();
        var order = CreateOrder(context, "owner-user", orderId: 402, orderItemId: 502);
        var service = CreateCheckoutService(context);

        var action = () => service.StartCheckoutAsync("other-user", new CheckoutDto
        {
            OrderId = order.Id,
            FullName = "Other User",
            Email = "other@example.com",
            Address = "Address 2"
        });

        await Assert.ThrowsAsync<InvalidOperationException>(action);
        Assert.Empty(context.Checkouts);
        Assert.Empty(context.Payments);
    }

    private static ApplicationDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(options);
    }

    private static IMapper CreateMapper()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>(), NullLoggerFactory.Instance);
        return config.CreateMapper();
    }

    private static CheckoutService CreateCheckoutService(ApplicationDbContext context)
    {
        var options = Microsoft.Extensions.Options.Options.Create(new PaymentGatewayOptions
        {
            Gateway = "Demo",
            Currency = "usd",
            ApplicationBaseUrl = "https://localhost"
        });

        return new CheckoutService(context, new DemoPaymentGateway(), options);
    }

    private static Order CreateOrder(ApplicationDbContext context, string userId, int orderId, int orderItemId)
    {
        var category = new Category { Id = orderId + 1000, Name = "Checkout Category", IconUrl = "https://example.com/checkout-category.jpg" };
        var product = new Product
        {
            Id = orderId + 2000,
            Name = "Checkout Product",
            Description = "Checkout product",
            Price = 15m,
            ImageUrl = "https://example.com/checkout-product.jpg",
            IsAvailable = true,
            CategoryId = category.Id,
            Category = category
        };

        var order = new Order
        {
            Id = orderId,
            Number = orderId + 700000,
            IdentityUserId = userId,
            Status = OrderStatus.InProgress,
            OrderTime = DateTime.UtcNow,
            TotalAmount = 15m
        };

        var item = new OrderItem
        {
            Id = orderItemId,
            OrderId = order.Id,
            Order = order,
            ProductId = product.Id,
            Product = product,
            Quantity = 1
        };

        order.OrderItems.Add(item);
        context.Categories.Add(category);
        context.Products.Add(product);
        context.Orders.Add(order);
        context.OrderItems.Add(item);
        context.SaveChanges();

        return order;
    }
}
