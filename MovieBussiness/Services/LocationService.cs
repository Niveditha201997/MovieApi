using MovieData.Repository;
using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBussiness.Services
{
    public class LocationService
    {
        ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }



        //add Location
        public void AddLocation(Location locations)
        {
            _locationRepository.AddLocation(locations);
        }



        //update Location
        public void UpdateLocation(Location locations)
        {
            _locationRepository.UpdateLocation(locations);
        }



        //delete locations
        public void DeleteLocation(int locationsId)
        {
            _locationRepository.DeleteLocation(locationsId);
        }




        //get getlocationsbyid
        public Location GetLocationById(int locationsId)
        {
            return _locationRepository.GetLocationById(locationsId);
        }



        //get getlocations
        public IEnumerable<Location> GetLocation()
        {
            return _locationRepository.GetLocation();
        }
    }
}
