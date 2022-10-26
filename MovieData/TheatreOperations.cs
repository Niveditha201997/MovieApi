using Microsoft.EntityFrameworkCore;
using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieData
{
    public class TheatreOperations
    {
        AllDbContext db = null;
        public TheatreOperations(AllDbContext db)
        {
            this.db = db;
        }
        public string AddTheatre(Theatre theatre)
        {
            db = new AllDbContext();
            db.theatre.Add(theatre);
            db.SaveChanges();
            return "Saved";
        }
        public string UpdateTheatre(Theatre theatre)
        {
            db = new AllDbContext();
            db.Entry(theatre).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated";
        }
        public string DeleteTheatre(Theatre theatreId)
        {
            db = new AllDbContext();
            Theatre theatreobj = db.theatre.Find(theatreId);
            db.Entry(theatreobj).State = EntityState.Deleted;
            db.SaveChanges();
            return "Deleted";
        }
        public List<Theatre> ShowAll()
        {
            db = new AllDbContext();
            List<Theatre> theatreList = db.theatre.ToList();
            return theatreList;
        }
        //public List<Theatre> ShowAllByTheatreType(string type)
        //{
        //    db = new DbContext();
        //    List<Theatre> theatreList = db.theatre.ToList();

            //Linq query-select * from movie where movietype='type'
            //var result = from theatre in theatreList
            //             where theatre.TheatreType == type
            //             select theatre;
            //select new Movie
            //{
            //    Id = movies.Id,
            //    Name = movies.Name,
            //};

            //List<Theatre> theatreResult = new List<Theatre>();
            //foreach (var item in result) //Linq query execution
            //{
            //    theatreList.Add(item);
            //}
        //    return theatreResult;
        //}
        public Theatre ShowTheatreById(int theatreId)
        {
            db = new AllDbContext();
            Theatre threatre = db.theatre.Find(theatreId);
            return new Theatre();
        }
    }
}
