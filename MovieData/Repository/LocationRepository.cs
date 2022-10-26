using Microsoft.EntityFrameworkCore;
using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieData.Repository
{
    public class LocationRepository : ILocationRepository
    {
        AllDbContext _locationsDbcontext;
        public LocationRepository(AllDbContext locationsDbcontext)
        {
            _locationsDbcontext = locationsDbcontext;
        }
        public void AddLocation(Location locations)
        {
            _locationsDbcontext.locations.Add(locations);
            _locationsDbcontext.SaveChanges();
        }

        public void DeleteLocation(Location locations)
        {
            throw new NotImplementedException();
        }

        public void DeleteLocation(int locationsId)
        {
            var locations = _locationsDbcontext.locations.Find(locationsId);
            _locationsDbcontext.locations.Remove(locations);
            _locationsDbcontext.SaveChanges();
        }

        public IEnumerable<Location> GetLocation()
        {
            return _locationsDbcontext.locations.ToList();
        }

        public Location GetLocationById(int locationsId)
        {
            return _locationsDbcontext.locations.Find(locationsId);
        }

        public void UpdateLocation(Location locations)
        {
            _locationsDbcontext.Entry(locations).State = EntityState.Modified;
            _locationsDbcontext.SaveChanges();
        }
    }
}
