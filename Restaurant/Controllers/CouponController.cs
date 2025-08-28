using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.DTOs;
using System.Linq;

namespace Restaurant.Controllers
{
    public class CouponController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper _mapper;
        public CouponController(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this._mapper = mapper;
        }


        [HttpGet]
        public IActionResult Add()
        {
            CouponFormDto couponFormDto = new CouponFormDto();
            return View(couponFormDto);
        }

        
        [HttpPost]
        public IActionResult Add(CouponFormDto couponFormDto)
        {

            var coupon = new Coupon
            {
                Percentage = (PercentageRate)couponFormDto.Percentage,
                StartDate = couponFormDto.StartDate,
                EndDate = couponFormDto.EndDate,
                Code = couponFormDto.Code
            };

            data.Coupons.Add(coupon);
            data.SaveChanges();

            return RedirectToAction("getall");
        }
        [HttpGet]
        public IActionResult Getall()
        {
            var coupons = data.Coupons.ToList();
            var couponDto = _mapper.Map<List<CouponFormDto>>(coupons);
            return View(couponDto);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var coupon = data.Coupons.FirstOrDefault(c => c.Id == id);
            if (coupon == null)
            {
                return NotFound();
            }

            
            var dto = _mapper.Map<CouponFormDto>(coupon);
            
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(CouponFormDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var coupon = data.Coupons.FirstOrDefault(c => c.Id == model.Id);
            if (coupon == null)
            {
                return NotFound();
            }

            coupon.Percentage = (PercentageRate)model.Percentage;
            coupon.StartDate = model.StartDate;
            coupon.EndDate = model.EndDate;
            coupon.Code = model.Code;

            data.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var coupon = data.Coupons.FirstOrDefault(c => c.Id == id);
            if (coupon == null)
            {
                return NotFound();
            }

           

            data.Coupons.Remove(coupon);
            data.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
