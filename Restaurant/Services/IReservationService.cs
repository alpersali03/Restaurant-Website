using Restaurant.Data.Models;
using Restaurant.DTOs;

namespace Restaurant.Services
{
    public interface IReservationService
    {
        List<ReservationFormDto> GetAll();
        void Add(ReservationFormDto reservation);
        void Edit(ReservationDto reservation);
        void Delete(int id);
        Reservation? GetById(int id);
    }
}
