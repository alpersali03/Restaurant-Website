using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.DTOs;
using Restaurant.Extensions;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        //private readonly ApplicationDbContext data;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OrderController(ApplicationDbContext data, IMapper mapper, IOrderService orderService, IProductService productService)
        {
            //this.data = data;
            this._mapper = mapper;
            this._orderService = orderService;
            this._productService = productService;
        }

        [HttpGet]
        public IActionResult AddProduct(int productId)
        {
            var userId = User.GetId();

            _orderService.Add(userId, productId);

            return RedirectToAction("GetAll", "Menu"); // or your cart page
        }

        [HttpPost]
        public IActionResult AddProduct(OrderFormDto orderFormDto)
        {
            var userId = User.GetId(); // Extension method or however you're getting the user

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var orderDto = _orderService.Add(userId, orderFormDto.ProductId);

            // Redirect to a details page, or pass to the view as needed
            return RedirectToAction("Details", new { id = orderDto.Id });
        }

        [HttpGet]
        public IActionResult Getall()
        {
            var userId = User.GetId();
            var orders = _orderService.GetOrdersInProgress(userId);
            var ordersAmount = _orderService.GetTotalPrice(userId);
            //var orders = data.Orders.ToList(); 
            var orderDto = _mapper.Map<List<OrderFormDto>>(orders);
            if(orderDto == null)
            {
                return Empty;
            }
            return View(orderDto);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = _orderService.GetById(id);
            //var order = this.data.Orders.FirstOrDefault(o => o.Id == id);
            //if (order == null)
            //{
            //    return NotFound();
            //}
            var orderDto = _mapper.Map<OrderFormDto>(order);
            return View(orderDto);
        }
        [HttpPost]
        public IActionResult Edit(OrderDto orderDto)
        {
             _orderService.Edit(orderDto);

             return RedirectToAction("GetAll");

        }
        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    //_orderService.Delete(id);
        //    //return RedirectToAction("getall");

        //}
       
    }
}
