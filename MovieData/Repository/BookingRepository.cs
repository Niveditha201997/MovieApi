using Microsoft.EntityFrameworkCore;
using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieData.Repository
{
    public class BookingRepository : IBookingRepository
    {
        AllDbContext _bookingDbcontext;
        public BookingRepository(AllDbContext bookingDbcontext)
        {
            _bookingDbcontext = bookingDbcontext;
        }
        public void AddBooking(Booking bookings)
        {
            _bookingDbcontext.bookings.Add(bookings);
            _bookingDbcontext.SaveChanges();
        }

        public void DeleteBooking(Booking bookings)
        {
            throw new NotImplementedException();
        }

        public void DeleteBooking(int bookingsId)
        {
            var bookings = _bookingDbcontext.bookings.Find(bookingsId);
            _bookingDbcontext.bookings.Remove(bookings);
            _bookingDbcontext.SaveChanges();
        }

        public IEnumerable<Booking> GetBooking()
        {
            return _bookingDbcontext.bookings.ToList();
        }

        public Booking GetBookingById(int bookingsId)
        {
            return _bookingDbcontext.bookings.Find(bookingsId);
        }

        public void UpdateBooking(Booking bookings)
        {
            _bookingDbcontext.Entry(bookings).State = EntityState.Modified;
            _bookingDbcontext.SaveChanges();
        }
    }
}
