using Restaurant.Data.Models;
using Restaurant.DTOs;

namespace Restaurant.Services
{
    public interface IOrderService
    {
        List<Order> GetAll();
        Order Add(string userId, int productId, int quantity = 1);
        void Edit(OrderDto orderDto);
        Order? GetById(int id);
        Order? GetOrderInProgressUserId(string userId);
        List<Order> GetOrdersInProgress(string userId);
        decimal GetTotalPrice(string userId);
        void IncreaseTotalAmount(int orderId, int orderItemId);
        void DecreaseTotalAmount(int orderId, int orderItemId, int quantity = 1);
    }
}
