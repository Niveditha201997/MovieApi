using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieData.Repository
{
    public interface IBookingRepository
    {
        void AddBooking(Booking bookings);
        void UpdateBooking(Booking bookings);
        void DeleteBooking(Booking bookings);
        Booking GetBookingById(int bookingsId);
        IEnumerable<Booking> GetBooking();
        void DeleteBooking(int bookingsId);
    }
}
