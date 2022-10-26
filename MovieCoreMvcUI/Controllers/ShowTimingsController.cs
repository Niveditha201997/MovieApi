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
    public class ShowTimingsController : Controller
    {
        private IConfiguration _configuration;
        public ShowTimingsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ActionResult> Index()
        {
            IEnumerable<ShowTimings> showTimingsresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTimings/GetShowTimings";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        showTimingsresult = JsonConvert.DeserializeObject<IEnumerable<ShowTimings>>(result);
                    }
                }
            }
            return View(showTimingsresult);
        }
        public IActionResult ShowTimingsEntry()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShowTimingsEntry(ShowTimings showTimings)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(showTimings), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTimings/AddShowTimings";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "ShowTimings details saved sucessfully!!";
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
        public async Task<IActionResult> EditShowTimings(int Id)
        {
            ShowTimings showTimings = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTimings/GetShowTimingsById?Id=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        showTimings = JsonConvert.DeserializeObject<ShowTimings>(result);
                    }
                }
            }
            return View(showTimings);
        }

        [HttpPost]

        public async Task<IActionResult> EditShowTimings(ShowTimings showTimings)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(showTimings), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTimings/UpdateShowTimings";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "ShowTimings details updated sucessfully!!";
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
        public async Task<IActionResult> DeleteShowTimings(int Id)
        {
            ShowTimings showTimings = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTimings/GetShowTimingsById?showTimingsId=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        showTimings = JsonConvert.DeserializeObject<ShowTimings>(result);
                    }
                }
            }
            return View(showTimings);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteShowTimings(ShowTimings showTimings)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "ShowTimings/DeleteShowTimings?showTimingsId=" + showTimings.Id;

                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "ShowTimings details deleted sucessfully!!";
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
