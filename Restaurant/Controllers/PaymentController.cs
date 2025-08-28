using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.DTOs;
using System.Linq;

namespace Restaurant.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper _mapper;

        public PaymentController(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this._mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            
            var paymentFormDto = new PaymentFormDto
            {
                PaidAt = DateTime.Now 
            };
            return View(paymentFormDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Payment payment)
        {
            if (payment == null)
            {
                return BadRequest();
            }

            
            if (payment.PaidAt == default)
                payment.PaidAt = DateTime.Now;

            this.data.Payments.Add(payment);
            this.data.SaveChanges();

            
            return RedirectToAction("Getall");
        }

        [HttpGet]
        public IActionResult Getall()
        {
            
            var payments = this.data.Payments
                .Include(p => p.Order) 
                .OrderByDescending(p => p.PaidAt)
                .ToList();
            if(payments ==  null || payments.Count == 0) 
            { 
                return BadRequest(); 
            }
            var paymentDto = _mapper.Map<List<PaymentFormDto>>(payments);
            return View(paymentDto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var payment = this.data.Payments.FirstOrDefault(c => c.Id == id);
            if (payment == null)
            {
                return NotFound();
            }
            var paymentDto = _mapper.Map<PaymentFormDto>(payment);
            return View(paymentDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Payment payment)
        {
            var existingPayment = this.data.Payments.FirstOrDefault(c => c.Id == payment.Id);
            if (existingPayment == null)
            {
                return NotFound();
            }

            existingPayment.PaidAt = payment.PaidAt;
            existingPayment.Amount = payment.Amount;
            existingPayment.Method = payment.Method;
            existingPayment.OrderId = payment.OrderId; 

            this.data.SaveChanges();

            
            return RedirectToAction("Getall");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancell(int id)
        {
            var cancellingPayment = this.data.Payments.FirstOrDefault(x => x.Id == id);
            if (cancellingPayment == null)
            {
                return BadRequest();
            }

            this.data.Payments.Remove(cancellingPayment);
            this.data.SaveChanges();

            return RedirectToAction("Getall");
        }
    }
}
