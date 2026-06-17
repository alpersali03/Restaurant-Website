using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Extensions;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    [Authorize]
    public class OrderCartController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;

        public OrderCartController(IOrderService orderService, IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public IActionResult GetCartProducts()
        {
            var userId = User.GetId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var order = _orderService.GetOrderInProgressUserId(userId);
            return View("GetAll", order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveItem(int orderItemId)
        {
            var userId = User.GetId();
            if (string.IsNullOrWhiteSpace(userId))
            {
                return Unauthorized();
            }

            var cart = _orderService.GetOrderInProgressUserId(userId);
            var item = cart?.OrderItems.FirstOrDefault(x => x.Id == orderItemId);

            if (cart != null && item != null)
            {
                var quantity = item.Quantity;
                _orderService.DecreaseTotalAmount(cart.Id, item.Id, quantity);
                _orderItemService.Delete(item.Id);
            }

            return RedirectToAction(nameof(GetCartProducts));
        }

        [HttpGet]
        public IActionResult Checkout(int id)
        {
            return RedirectToAction("Index", "Checkout", new { orderId = id });
        }
    }
}
