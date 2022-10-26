using Microsoft.EntityFrameworkCore;
using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieData
{
    public class BookingOperations
    {
        AllDbContext db = null;
        public BookingOperations(AllDbContext db)
        {
            this.db = db;
        }
        public string AddBooking(Booking bookings)
        {
            db = new AllDbContext();
            db.bookings.Add(bookings);
            db.SaveChanges();
            return "Saved";
        }
        public string UpdateBooking(Booking bookings)
        {
            db = new AllDbContext();
            db.Entry(bookings).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated";
        }
        public string DeleteBooking(Booking bookingsId)
        {
            db = new AllDbContext();
            Booking bookingsobj = db.bookings.Find(bookingsId);
            db.Entry(bookingsobj).State = EntityState.Deleted;
            db.SaveChanges();
            return "Deleted";
        }
        public List<Booking> ShowAll()
        {
            db = new AllDbContext();
            List<Booking> bookingsList = db.bookings.ToList();
            return bookingsList;
        }

        public Booking ShowShowBookingById(int bookingsId)
        {
            db = new AllDbContext();
            Booking bookings = db.bookings.Find(bookingsId);
            return new Booking();
        }
    }
}
