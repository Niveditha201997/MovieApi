using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MovieEntity.Models;
using MovieBussiness.Services;


namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private TheatreService _theatreService;
        public TheatreController(TheatreService theatreService)
        {
            _theatreService = theatreService;
        }

        [HttpGet("GetTheatre")]
        public IEnumerable<Theatre> GetTheatre()
        {
            return _theatreService.GetTheatre();
        }

        [HttpPost("AddTheatre")]
        public IActionResult AddTheatre([FromBody] Theatre theatre)
        {
            _theatreService.AddTheatre(theatre);
            return Ok("Theatre created successfully!!");
        }

        [HttpDelete("DeleteTheatre")]
        public IActionResult DeleteTheatre(int theatreId)
        {
            _theatreService.DeleteTheatre(theatreId);
            return Ok("Theatre deleted sucessfully!!");
        }

        [HttpPut("UpdateTheatre")]
        public IActionResult UpdateTheatre([FromBody] Theatre theatre)
        {
            _theatreService.UpdateTheatre(theatre);
            return Ok("Theatre Updated sucessfully");
        }

        [HttpGet("GetTheatreById")]
        public Theatre GetTheatreById(int theatreId)
        {
            return _theatreService.GetTheatreById(theatreId);
        }
    }
}
