using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTOs;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService couponService;
        private readonly IMapper mapper;

        public CouponController(ICouponService couponService, IMapper mapper)
        {
            this.couponService = couponService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new CouponFormDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CouponFormDto couponFormDto)
        {
            if (!ModelState.IsValid)
            {
                return View(couponFormDto);
            }

            couponService.Add(couponFormDto);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return View(couponService.GetAll());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var coupon = couponService.GetById(id);
            if (coupon == null)
            {
                return NotFound();
            }

            return View(mapper.Map<CouponFormDto>(coupon));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CouponFormDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            couponService.Edit(new CouponDto
            {
                Id = model.Id,
                Code = model.Code,
                Percentage = (Data.Models.PercentageRate)model.Percentage,
                StartDate = model.StartDate,
                EndDate = model.EndDate
            });

            return RedirectToAction(nameof(GetAll));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            couponService.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
