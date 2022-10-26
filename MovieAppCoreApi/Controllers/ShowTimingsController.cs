using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MovieEntity.Models;
using MovieBussiness.Services;


namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimingsController : ControllerBase
    {
        private ShowTimingsService _showTimingsService;
        public ShowTimingsController(ShowTimingsService showTimingsService)
        {
            _showTimingsService = showTimingsService;
        }

        [HttpGet("GetShowTimings")]
        public IEnumerable<ShowTimings> GetShowTimings()
        {
            return _showTimingsService.GetShowTimings();
        }

        [HttpPost("AddShowTimings")]
        public IActionResult AddShowTimings([FromBody] ShowTimings showTimings)
        {
            _showTimingsService.AddShowTimings(showTimings);
            return Ok("ShowTimings created successfully!!");
        }

        [HttpDelete("DeleteShowTimings")]
        public IActionResult DeleteShowTimings(int showTimingsId)
        {
            _showTimingsService.DeleteShowTimings(showTimingsId);
            return Ok("ShowTimings deleted sucessfully!!");
        }

        [HttpPut("UpdateShowTimings")]
        public IActionResult UpdateShowTimings([FromBody] ShowTimings showTimings)
        {
            _showTimingsService.UpdateShowTimings(showTimings);
            return Ok("ShowTimings Updated sucessfully");
        }
        [HttpGet("GetShowTimingsById")]
        public ShowTimings GetShowTimingsById(int showTimingsId)
        {
            return _showTimingsService.GetShowTimingsById(showTimingsId);
        }
    }
}
