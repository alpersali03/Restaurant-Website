using AutoMapper;
using Restaurant.Data.Models;
using Restaurant.Data;
using Restaurant.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Services
{
	public class OrderService : IOrderService
	{
		private readonly ApplicationDbContext data;
		private readonly IMapper _mapper;
		private readonly IOrderItemService _orderItemService;

		public OrderService(ApplicationDbContext data, IMapper mapper, IOrderItemService orderItemService)
		{
			this.data = data;
			_mapper = mapper;
			_orderItemService = orderItemService;
		}

		public Order Add(string userId, int productId, int quantity = 1)
		{
			if (string.IsNullOrWhiteSpace(userId))
				throw new ArgumentNullException(nameof(userId), "User is required!");

			var product = data.Products.FirstOrDefault(p => p.Id == productId);
			if (product == null)
				throw new ArgumentException("Invalid product ID");

			var order = data.Orders.Include(o => o.OrderItems).FirstOrDefault(o => o.IdentityUserId == userId && o.Status == OrderStatus.InProgress);

			if (order == null)
			{
				Random random = new Random();
				int number;
				do
				{
					number = random.Next(100000, 999999);
				} while (data.Orders.Any(o => o.Number == number));

				order = new Order
				{
					Number = number,
					TotalAmount = 0,
					Status = OrderStatus.InProgress,
					OrderTime = DateTime.Now,
					IdentityUserId = userId,
					OrderItems = new List<OrderItem>()
				};

				data.Orders.Add(order);
				data.SaveChanges();
			}


			_orderItemService.Add(order.Id, productId, quantity);

			order.TotalAmount += product.Price * quantity;

			data.SaveChanges();

			return order;
		}

		public void Delete(int id)
		{
			var deletingOrder = GetById(id);
			if (deletingOrder == null)
			{
				throw new ArgumentNullException("Order not found!");
			}

			data.Orders.Remove(deletingOrder);
			data.SaveChanges();
		}

		public void Edit(OrderDto orderDto)
		{
			if (orderDto == null)
				throw new ArgumentNullException(nameof(orderDto));

			var order = data.Orders.FirstOrDefault(o => o.Id == orderDto.Id);
			if (order == null)
				throw new InvalidOperationException("The order cannot be edited!");

			_mapper.Map(orderDto, order);
			data.SaveChanges();
		}

		public List<Order> GetAll()
		{
			return data.Orders
				.Include(o => o.OrderItems)
				.ThenInclude(oi => oi.Product)
				.ToList();
		}

		public Order? GetOrderInProgressUserId(string userId)
		{
			var order = this.data.Orders.Include(or => or.OrderItems).ThenInclude(oi => oi.Product).FirstOrDefault(o => o.IdentityUserId == userId && o.Status == OrderStatus.InProgress);
			return order;


		}


		public Order? GetById(int id)
		{
			return data.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).FirstOrDefault(o => o.Id == id);
		}


		public List<Order> GetOrdersInProgress(string userId)
		{
			var orders = this.data.Orders.Include(or => or.OrderItems).ThenInclude(oi => oi.Product).Where(o => o.IdentityUserId == userId && o.Status == OrderStatus.InProgress).ToList();
			return orders;
		}

		public decimal GetTotalPrice(string userId)
		{

			var x = data.Orders.Where(o => o.IdentityUserId == userId && o.Status == OrderStatus.InProgress).ToList();

			return data.Orders.Where(o => o.IdentityUserId == userId && o.Status == OrderStatus.InProgress).Sum(o => o.TotalAmount);
		}

		public void IncreaseTotalAmount(int orderId, int orderItemId)
		{
			var order = this.data.Orders.FirstOrDefault(x => x.Id == orderId);

			if (order == null)
			{
				return;
			}
			var item = this.data.OrderItems.Include(p=>p.Product).FirstOrDefault(x => x.Id == orderItemId);
            if (item == null)
            {
                return;
            }

			order.TotalAmount += item.Product?.Price ?? 0m;
			this.data.SaveChanges();
		}

		public void DecreaseTotalAmount(int orderId, int orderItemId, int quantity = 1)
		{
			var order = this.data.Orders.FirstOrDefault(x => x.Id == orderId);

			if (order == null)
			{
				return;
			}
			var item = this.data.OrderItems.Include(p => p.Product).FirstOrDefault(x => x.Id == orderItemId);
            if (item == null)
            {
                return;
            }

			order.TotalAmount -= (item.Product?.Price ?? 0m) * quantity;
            if (order.TotalAmount < 0)
            {
                order.TotalAmount = 0;
            }
			this.data.SaveChanges();
		}
	}
}
