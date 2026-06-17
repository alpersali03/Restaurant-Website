using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return View(paymentService.GetAll());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var payment = paymentService.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }
    }
}
