using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.DTOs;

namespace Restaurant.Controllers
{
	public class ReservationController : Controller
	{
		private readonly ApplicationDbContext data;
		private readonly IMapper _mapper;
		public ReservationController(ApplicationDbContext data, IMapper mapper)
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
			ReservationFormDto reservationFormDto = new ReservationFormDto();
			return View(reservationFormDto);
		}
		[HttpPost]
		public IActionResult Add(ReservationFormDto reservationFormDto)
		{

			var reservation = new Reservation();
			{
				reservation.Status = (ReservationStatus)reservationFormDto.Status;
				reservation.Notes = reservationFormDto.Notes;
				reservation.GuestCount = reservationFormDto.GuestCount;
				reservation.ReservationDate = reservationFormDto.ReservationDate;
                reservation.PhoneNumber = reservationFormDto.PhoneNumber;
                reservation.CustomerName = reservationFormDto.CustomerName;
            }

			data.Reservations.Add(reservation);
			data.SaveChanges();

			return RedirectToAction("getall");
		}
		[HttpGet]
		public IActionResult Getall()
		{
			var reservations = data.Reservations.ToList();
			var reservationDto = _mapper.Map<List<ReservationFormDto>>(reservations);
			return View(reservationDto);
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var reservation = data.Reservations.FirstOrDefault(r => r.Id == id);
			if (reservation == null)
			{
				return NotFound();
			}


			var reservationDto = _mapper.Map<ReservationFormDto>(reservation);

			return View(reservationDto);
		}

		[HttpPost]
		public IActionResult Edit(ReservationFormDto reservationFromDto)
		{
			if (!ModelState.IsValid)
			{
				return View(reservationFromDto);
			}

			var reservation = data.Reservations.FirstOrDefault(r => r.Id == reservationFromDto.Id);
			if (reservation == null)
			{
				return NotFound();
			}

			reservation.Status = (ReservationStatus)reservationFromDto.Status;
			reservation.Notes = reservationFromDto.Notes;
			reservation.GuestCount = reservationFromDto.GuestCount;
			reservation.ReservationDate = reservationFromDto.ReservationDate;
            reservation.PhoneNumber = reservationFromDto.PhoneNumber;
            reservation.CustomerName = reservationFromDto.CustomerName;

            data.SaveChanges();

			return RedirectToAction(nameof(Index));
		}


		[HttpPost]
		public IActionResult Delete(int id)
		{
			var reservation = data.Reservations.FirstOrDefault(r => r.Id == id);
			if (reservation == null)
			{
				return NotFound();
			}



			data.Reservations.Remove(reservation);
			data.SaveChanges();

			return RedirectToAction(nameof(Index));
		}
	}
}
