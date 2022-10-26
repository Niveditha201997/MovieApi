using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBussiness.Services;
using MovieEntity.Models;
using System.Collections.Generic;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private BookingService _bookingService;
        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("GetBooking")]
        public IEnumerable<Booking> GetBooking()
        {
            return _bookingService.GetBooking();
        }

        [HttpPost("AddBooking")]
        public IActionResult AddBooking([FromBody] Booking bookings)
        {
            _bookingService.AddBooking(bookings);
            return Ok("Booking created successfully!!");
        }

        [HttpDelete("DeleteBooking")]
        public IActionResult DeleteBooking(int bookingsId)
        {
            _bookingService.DeleteBooking(bookingsId);
            return Ok("Booking deleted sucessfully!!");
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking([FromBody] Booking bookings)
        {
            _bookingService.UpdateBooking(bookings);
            return Ok("Booking Updated sucessfully");
        }

        [HttpGet("GetBookingById")]
        public Booking GetBookingById(int bookingsId)
        {
            return _bookingService.GetBookingById(bookingsId);
        }
    }
}
