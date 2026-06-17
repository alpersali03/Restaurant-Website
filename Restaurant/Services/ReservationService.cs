using AutoMapper;
using Restaurant.Data;
using Restaurant.Data.Models;
using Restaurant.DTOs;

namespace Restaurant.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public ReservationService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public void Add(ReservationFormDto reservation)
        {
            if (string.IsNullOrWhiteSpace(reservation.CustomerName))
            {
                throw new ArgumentException("Customer name is required.", nameof(reservation));
            }

            var mapped = mapper.Map<Reservation>(reservation);
            data.Reservations.Add(mapped);
            data.SaveChanges();
        }

        public void Edit(ReservationDto reservation)
        {
            var existingReservation = data.Reservations.FirstOrDefault(item => item.Id == reservation.Id);
            if (existingReservation == null)
            {
                throw new ArgumentException("Reservation not found.", nameof(reservation));
            }

            mapper.Map(reservation, existingReservation);
            data.SaveChanges();
        }

        public void Delete(int id)
        {
            var reservation = GetById(id);
            if (reservation == null)
            {
                throw new ArgumentException("Reservation not found.", nameof(id));
            }

            data.Reservations.Remove(reservation);
            data.SaveChanges();
        }

        public List<ReservationFormDto> GetAll()
        {
            return mapper.Map<List<ReservationFormDto>>(data.Reservations.OrderBy(item => item.ReservationDate).ToList());
        }

        public Reservation? GetById(int id)
        {
            return data.Reservations.FirstOrDefault(item => item.Id == id);
        }
    }
}
