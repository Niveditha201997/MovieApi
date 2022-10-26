using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieData.Repository
{
    public interface ILocationRepository
    {
        void AddLocation(Location locations);
        void UpdateLocation(Location locations);
        void DeleteLocation(Location locations);
        Location GetLocationById(int locationsId);
        IEnumerable<Location> GetLocation();
        void DeleteLocation(int locationsId);
    }
}
