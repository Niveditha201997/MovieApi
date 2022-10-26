using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieEntity.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMvcUI.Controllers
{
    public class BookingController : Controller
    {
        private IConfiguration _configuration;
        public BookingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Booking> bookingsresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Booking/GetBooking";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        bookingsresult = JsonConvert.DeserializeObject<IEnumerable<Booking>>(result);
                    }
                }
            }
            return View(bookingsresult);
        }
        public IActionResult BookingEntry()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookingEntry(Booking bookings)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(bookings), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Booking/AddBooking";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Booking details saved sucessfully!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> EditBooking(int Id)
        {
            Booking bookings = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Booking/GetBookingById?Id=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        bookings = JsonConvert.DeserializeObject<Booking>(result);
                    }
                }
            }
            return View(bookings);

        }

        [HttpPost]

        public async Task<IActionResult> EditBooking(Booking bookings)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(bookings), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Booking/UpdateBooking";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Booking details updated sucessfully!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> DeleteBooking(int Id)
        {
            Booking bookings = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Booking/GetBookingById?bookingsId=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        bookings = JsonConvert.DeserializeObject<Booking>(result);
                    }
                }
            }
            return View(bookings);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBooking(Booking bookings)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Booking/DeleteBooking?bookingsId=" + bookings.Id;

                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Booking details deleted sucessfully!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }
    }
}
