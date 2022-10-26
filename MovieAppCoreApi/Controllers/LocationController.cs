using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBussiness.Services;
using MovieEntity.Models;
using System.Collections.Generic;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private LocationService _locationService;
        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("GetLocation")]
        public IEnumerable<Location> GetLocation()
        {
            return _locationService.GetLocation();
        }

        [HttpPost("AddLocation")]
        public IActionResult AddLocation([FromBody] Location locations)
        {
            _locationService.AddLocation(locations);
            return Ok("Location created successfully!!");
        }

        [HttpDelete("DeleteLocation")]
        public IActionResult DeleteLocation(int locationsId)
        {
            _locationService.DeleteLocation(locationsId);
            return Ok("Location deleted sucessfully!!");
        }

        [HttpPut("UpdateLocation")]
        public IActionResult UpdateLocation([FromBody] Location locations)
        {
            _locationService.UpdateLocation(locations);
            return Ok("Location Updated sucessfully");
        }

        [HttpGet("GetLocationById")]
        public Location GetLocationById(int locationsId)
        {
            return _locationService.GetLocationById(locationsId);
        }
    }
}
