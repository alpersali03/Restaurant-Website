using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTOs;
using Restaurant.Extensions;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrderController(IMapper mapper, IOrderService orderService)
        {
            this._mapper = mapper;
            this._orderService = orderService;
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return RedirectToAction("GetAll", "Menu");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(int productId)
        {
            var userId = User.GetId();
            if (string.IsNullOrWhiteSpace(userId))
            {
                return Unauthorized();
            }

            _orderService.Add(userId, productId);
            return RedirectToAction("GetAll", "Menu");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var userId = User.GetId();
            if (string.IsNullOrWhiteSpace(userId))
            {
                return Unauthorized();
            }

            var orders = _orderService.GetOrdersInProgress(userId);
            var orderDto = _mapper.Map<List<OrderFormDto>>(orders);

            if (orderDto == null)
            {
                return Empty;
            }

            return View(orderDto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = _orderService.GetById(id);
            var orderDto = _mapper.Map<OrderFormDto>(order);
            return View(orderDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderDto orderDto)
        {
            _orderService.Edit(orderDto);
            return RedirectToAction("GetAll");
        }
    }
}
