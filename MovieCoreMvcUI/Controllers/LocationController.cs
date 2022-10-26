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
    public class LocationController : Controller
    {
        private IConfiguration _configuration;
        public LocationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Location> locationsresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Location/GetLocation";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        locationsresult = JsonConvert.DeserializeObject<IEnumerable<Location>>(result);
                    }
                }
            }
            return View(locationsresult);
        }
        public IActionResult LocationEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LocationEntry(Location locations)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(locations), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Location/AddLocation";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Location details saved sucessfully!!";
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
        public async Task<IActionResult> EditLocation(int Id)
        {
            Location locations = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Location/GetLocationById?Id=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        locations = JsonConvert.DeserializeObject<Location>(result);
                    }
                }
            }
            return View(locations);

        }

        [HttpPost]

        public async Task<IActionResult> EditLocation(Location locations)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(locations), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Location/UpdateLocation";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Location details updated sucessfully!!";
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
        public async Task<IActionResult> DeleteLocation(int Id)
        {
            Location locations = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Location/GetLocationById?locationsId=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        locations = JsonConvert.DeserializeObject<Location>(result);
                    }
                }
            }
            return View(locations);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLocation(Location locations)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Location/DeleteLocation?locationsId=" + locations.Id;

                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Location details deleted sucessfully!!";
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
