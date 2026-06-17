using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTOs;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;
        private readonly IMapper mapper;

        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            this.reservationService = reservationService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ReservationFormDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ReservationFormDto reservationFormDto)
        {
            if (!ModelState.IsValid)
            {
                return View(reservationFormDto);
            }

            reservationService.Add(reservationFormDto);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return View(reservationService.GetAll());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var reservation = reservationService.GetById(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(mapper.Map<ReservationFormDto>(reservation));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ReservationFormDto reservationFormDto)
        {
            if (!ModelState.IsValid)
            {
                return View(reservationFormDto);
            }

            reservationService.Edit(mapper.Map<ReservationDto>(reservationFormDto));
            return RedirectToAction(nameof(GetAll));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            reservationService.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
