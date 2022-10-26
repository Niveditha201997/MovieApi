using MovieData.Repository;
using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBussiness.Services
{
    public class BookingService
    {
        IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }



        //add booking
        public void AddBooking(Booking bookings)
        {
            _bookingRepository.AddBooking(bookings);
        }



        //update booking
        public void UpdateBooking(Booking bookings)
        {
            _bookingRepository.UpdateBooking(bookings);
        }



        //delete booking
        public void DeleteBooking(int bookingsId)
        {
            _bookingRepository.DeleteBooking(bookingsId);
        }




        //get getbookingsbyid
        public Booking GetBookingById(int bookingsId)
        {
            return _bookingRepository.GetBookingById(bookingsId);
        }



        //get getbookings
        public IEnumerable<Booking> GetBooking()
        {
            return _bookingRepository.GetBooking();
        }
    }
}
