using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTOs;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    [Authorize]
    public class OrderItemController : Controller
    {
        private readonly IOrderItemService orderItemService;
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrderItemController(
            IOrderItemService orderItemService,
            IProductService productService,
			IOrderService orderService,
		    IMapper mapper)
        {
            this.orderItemService = orderItemService;
            this.productService = productService;
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Add(int orderId)
        {
            var dto = new OrderItemFormDto
            {
                OrderId = orderId,
                Products = productService.GetAll()
            };
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(OrderItemFormDto dto)
        {
            if (!ModelState.IsValid)
            {
                dto.Products = productService.GetAll();
                return View(dto);
            }

           // orderItemService.Add(dto);
            return RedirectToAction("Edit", "Order", new { id = dto.OrderId });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dto = orderItemService.GetById(id);
            if (dto == null)
            {
                return NotFound();
            }

            dto.Products = productService.GetAll();

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderItemFormDto dto)
        {
            if (!ModelState.IsValid)
            {
                dto.Products = productService.GetAll();
                return View(dto);
            }

            orderItemService.Edit(dto);
            return RedirectToAction("Edit", "Order", new { id = dto.OrderId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, int orderId)
        {
            orderItemService.Delete(id);
            return RedirectToAction("Edit", "Order", new { id = orderId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateQuantity(int orderItemId, int orderId, string change)
        {
            var item = orderItemService.GetById(orderItemId);
            if (item == null)
                return NotFound();

            if (change == "increase")
            {
                item.Quantity += 1;
                orderItemService.Edit(item);
                orderService.IncreaseTotalAmount(orderId, orderItemId);


            }
            else if (change == "decrease")
            {
                item.Quantity -= 1;
                if (item.Quantity <= 0)
                {
                    orderService.DecreaseTotalAmount(orderId, orderItemId);
                    orderItemService.Delete(orderItemId);
                }
                else
                {
                    orderItemService.Edit(item);
                    orderService.DecreaseTotalAmount(orderId, orderItemId);
                }
            }

            return RedirectToAction("GetAll", "Order");
        }

    }
}
