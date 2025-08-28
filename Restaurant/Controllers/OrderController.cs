using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.DTOs;

namespace Restaurant.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper _mapper;

        public OrderController(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            var orders = data.Orders.ToList();   
            return View(orders);
        }
        [HttpGet]
        public IActionResult Add()
        {
            OrderFormDto orderFormDto = new OrderFormDto();
            
            return View(orderFormDto);

        }
        [HttpPost]
        public IActionResult Add(OrderFormDto orderFormDto)
        {
            if(orderFormDto == null)
            {
                return NotFound();  
            }
            var order = new Order();
            order.Number = orderFormDto.Number;
            order.OrderItems = orderFormDto.OrderItems;
            order.OrderTime = orderFormDto.OrderTime;
            order.IdentityUser = orderFormDto.IdentityUser;
            order.Status = orderFormDto.Status;
            order.OrderItems = orderFormDto.OrderItems.ToList();

            this.data.Add(order);
            data.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult Getall()
        {
            var orders = data.Orders.ToList(); 
            var orderDto = _mapper.Map<List<OrderFormDto>>(orders);
            return View(orderDto);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = this.data.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            var orderDto = _mapper.Map<OrderFormDto>(order);
            return View(orderDto);
        }
        [HttpPost]
        public IActionResult Edit(OrderFormDto orderFormDto)
        {
            var existingOrder = this.data.Orders.FirstOrDefault(c => c.Id == orderFormDto.Id);
            if (existingOrder == null)
            {
                return NotFound();
            }
            existingOrder.Number = orderFormDto.Number;
            existingOrder.TotalAmount = orderFormDto.TotalAmount;  
            existingOrder.IdentityUser = orderFormDto.IdentityUser;
            existingOrder.OrderTime = orderFormDto.OrderTime;

            data.SaveChanges();
            return RedirectToAction("GetAll");

        }
        [HttpPost]
        public IActionResult Cancell(int id)
        {
            var deletingOrder = this.data.Orders.FirstOrDefault(x => x.Id == id);
            this.data.Remove(deletingOrder);
            data.SaveChanges();
            return RedirectToAction("getall");

        }
    }
}
