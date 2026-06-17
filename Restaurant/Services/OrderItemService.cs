using AutoMapper;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.DTOs;

namespace Restaurant.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public OrderItemService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public void Add(int orderId, int productId, int quantity = 1)
        {
            // var order = data.Orders.FirstOrDefault(o => o.Id == orderId);
            // data.OrderItems.Add(order);
            // var orderItem = new OrderItem
            // {
            //     OrderId = order.Id,
            //     ProductId = productId,
            //     Quantity = quantity
            // };

            // if (data.Products.Any(o => o.Orders == order))
            // {
            //     var orderQuantity = orderItem.Quantity += 1;
            // }
            // var quantityOrder = data.OrderItems.FirstOrDefault(o => o.OrderId == orderId);

            // data.OrderItems.Add(orderItem);

            var orders = data.OrderItems.Where(oi => oi.OrderId == orderId).ToList();

            if (orders.Count == 0)
            {
                var orderItem = new OrderItem
                {
                    OrderId = orderId,
                    ProductId = productId,
                    Quantity = quantity
                };

                var order = data.OrderItems.Add(orderItem);
                data.SaveChanges();
                return;
            }
            var currentProduct = orders.FirstOrDefault(oi => oi.ProductId == productId);

            if (currentProduct == null)
            {
                var orderItem = new OrderItem
                {
                    OrderId = orderId,
                    ProductId = productId,
                    Quantity = quantity
                };

                var order = data.OrderItems.Add(orderItem);
                data.SaveChanges();
                return;
            }
            else
            {
                var orderItemProduct = data.OrderItems.FirstOrDefault(oi => oi.OrderId == orderId && oi.ProductId == productId);
                if (orderItemProduct != null)
                {
                    orderItemProduct.Quantity++;
                    data.SaveChanges();
                }
            }
        }

        public void Edit(OrderItemFormDto dto)
        {
            var existing = data.OrderItems.FirstOrDefault(x => x.Id == dto.Id);
            if (existing == null) return;

            existing.ProductId = dto.ProductId;
            existing.Quantity = dto.Quantity;
            data.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = data.OrderItems.FirstOrDefault(x => x.Id == id);
            if (item == null) return;

            data.OrderItems.Remove(item);
            data.SaveChanges();
        }

        public OrderItemFormDto? GetById(int id)
        {
            var item = data.OrderItems
                .Include(x => x.Product)
                .FirstOrDefault(x => x.Id == id);

            return item == null ? null : mapper.Map<OrderItemFormDto>(item);
        }


        public List<OrderItemFormDto> GetByOrderId(int orderId)
        {
            var items = data.OrderItems
                .Include(o => o.Product)
                .Where(x => x.OrderId == orderId)
                .ToList();

            return mapper.Map<List<OrderItemFormDto>>(items);
        }
    }
}
