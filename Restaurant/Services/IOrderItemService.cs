using Restaurant.DTOs;

namespace Restaurant.Services
{
    public interface IOrderItemService
    {
        void Add(int orderId, int productId, int quantity = 1);
        void Edit(OrderItemFormDto dto);
        void Delete(int id);
        OrderItemFormDto? GetById(int id);
        List<OrderItemFormDto> GetByOrderId(int orderId);
    }
}
