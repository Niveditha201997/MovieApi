using Microsoft.EntityFrameworkCore;
using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieData
{
    public class ShowTimingsOperations
    {
        AllDbContext db = null;
        public ShowTimingsOperations(AllDbContext db)
        {
            this.db = db;
        }
        public string AddShowTimings(ShowTimings showTimings)
        {
            db = new AllDbContext();
            db.showTimings.Add(showTimings);
            db.SaveChanges();
            return "Saved";
        }
        public string UpdateShowTimings(ShowTimings showTimings)
        {
            db = new AllDbContext();
            db.Entry(showTimings).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated";
        }
        public string DeleteShowTimings(ShowTimings showTimingsId)
        {
            db = new AllDbContext();
            ShowTimings showTimingsobj = db.showTimings.Find(showTimingsId);
            db.Entry(showTimingsobj).State = EntityState.Deleted;
            db.SaveChanges();
            return "Deleted";
        }
        public List<ShowTimings> ShowAll()
        {
            db = new AllDbContext();
            List<ShowTimings> showTimingsList = db.showTimings.ToList();
            return showTimingsList;
        }
        
        public ShowTimings ShowShowTimingsById(int showTimingsId)
        {
            db = new AllDbContext();
            ShowTimings showTimings = db.showTimings.Find(showTimingsId);
            return new ShowTimings();
        }
    }
}
