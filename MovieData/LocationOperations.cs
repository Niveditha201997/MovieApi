using Microsoft.EntityFrameworkCore;
using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieData
{
    public class LocationOperations
    {
        AllDbContext db = null;
        public LocationOperations(AllDbContext db)
        {
            this.db = db;
        }
        public string AddLocation(Location locations)
        {
            db = new AllDbContext();
            db.locations.Add(locations);
            db.SaveChanges();
            return "Saved";
        }
        public string UpdateLocation(Location locations)
        {
            db = new AllDbContext();
            db.Entry(locations).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated";
        }
        public string DeleteLocation(Location locationsId)
        {
            db = new AllDbContext();
            Location locationsobj = db.locations.Find(locationsId);
            db.Entry(locationsobj).State = EntityState.Deleted;
            db.SaveChanges();
            return "Deleted";
        }
        public List<Location> ShowAll()
        {
            db = new AllDbContext();
            List<Location> locationsList = db.locations.ToList();
            return locationsList;
        }

        public Location ShowShowLocationById(int locationsId)
        {
            db = new AllDbContext();
            Location locations = db.locations.Find(locationsId);
            return new Location();
        }
    }
}
