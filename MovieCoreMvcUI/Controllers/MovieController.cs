using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MovieEntity.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMvcUI.Controllers
{
    public class MovieController : Controller
    {
        private IConfiguration _configuration;
        public MovieController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Movie> movieresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/GetMovies";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        movieresult = JsonConvert.DeserializeObject<IEnumerable<Movie>>(result);
                    }
                }
            }
            return View(movieresult);
        }
        public IActionResult MovieEntry()
        {
            List<SelectListItem> movieType = new List<SelectListItem>()
            {
                new SelectListItem{Value="Select",Text="select"},
                new SelectListItem{Value="Action",Text="Action  "},
                new SelectListItem{Value="Comedy",Text="Comedy"},
                new SelectListItem{Value="Drama",Text="Drama"},
                new SelectListItem{Value="Fantasy",Text="Fantasy"},
                new SelectListItem{Value="Horror",Text="Horror"},
                new SelectListItem{Value="Mystery",Text="Mystery"},
                new SelectListItem{Value="Romance",Text="Romance"},
                new SelectListItem{Value="Thriller",Text="Thriller"}
            };
            ViewBag.movieType = movieType;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>MovieEntry(Movie movie)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movie),Encoding.UTF8,"application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/AddMovie";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Movie details saved sucessfully!!";
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

        public async Task<IActionResult> EditMovie(int Id)
        {
            Movie movie = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/GetMovieById?Id="+Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        movie = JsonConvert.DeserializeObject<Movie>(result);
                    }
                }
            }
            return View(movie);

        }

        [HttpPost]

        public async Task<IActionResult> EditMovie(Movie movie)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/UpdateMovie";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Movie details updated sucessfully!!";
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
        public async Task<IActionResult> DeleteMovie(int Id)
        {
            Movie movie = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/GetMovieById?movieId=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        movie = JsonConvert.DeserializeObject<Movie>(result);
                    }
                }
            }
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMovie(Movie movie)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Movie/DeleteMovie?movieId=" + movie.Id;

                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Movie details deleted sucessfully!!";
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
