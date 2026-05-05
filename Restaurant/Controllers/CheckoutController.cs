using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTOs;
using Restaurant.Extensions;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ICheckoutService checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            this.checkoutService = checkoutService;
        }

        [HttpGet]
        public IActionResult Index(int orderId)
        {
            var userId = User.GetId();
            if (string.IsNullOrWhiteSpace(userId))
            {
                return Unauthorized();
            }

            var dto = checkoutService.BuildCheckout(userId, orderId);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CheckoutDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var userId = User.GetId();
            if (string.IsNullOrWhiteSpace(userId))
            {
                return Unauthorized();
            }

            var redirectUrl = await checkoutService.StartCheckoutAsync(userId, dto, cancellationToken);
            return Redirect(redirectUrl);
        }

        [HttpGet]
        public async Task<IActionResult> Success(string sessionId, CancellationToken cancellationToken)
        {
            var userId = User.GetId();
            if (string.IsNullOrWhiteSpace(userId))
            {
                return Unauthorized();
            }

            var isConfirmed = await checkoutService.ConfirmPaymentAsync(userId, sessionId, cancellationToken);
            if (!isConfirmed)
            {
                return RedirectToAction(nameof(Cancel), new { sessionId });
            }

            return View("ThankYou");
        }

        [HttpGet]
        public async Task<IActionResult> Cancel(string sessionId, CancellationToken cancellationToken)
        {
            var userId = User.GetId();
            if (!string.IsNullOrWhiteSpace(userId) && !string.IsNullOrWhiteSpace(sessionId))
            {
                await checkoutService.CancelPaymentAsync(userId, sessionId, cancellationToken);
            }

            return View();
        }
    }
}
