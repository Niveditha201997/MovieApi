using Microsoft.EntityFrameworkCore;
using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace MovieData.Repository
{
    public class TheatreRepository : ITheatreRepository
    {
        AllDbContext _theatreDbcontext;
        public TheatreRepository(AllDbContext theatreDbcontext)
        {
            _theatreDbcontext = theatreDbcontext;
        }
        public void AddTheatre(Theatre theatre)
        {
            _theatreDbcontext.theatre.Add(theatre);
            _theatreDbcontext.SaveChanges();
        }        
        public void DeleteTheatre(Theatre theatre)
        {
            throw new NotImplementedException();
        }

        public void DeleteTheatre(int theatreId)
        {
            var theatre = _theatreDbcontext.theatre.Find(theatreId);
            _theatreDbcontext.theatre.Remove(theatre);
            _theatreDbcontext.SaveChanges();
        }        

        public IEnumerable<Theatre> GetTheatre()
        {
            return _theatreDbcontext.theatre.ToList();
        }

        public Theatre GetTheatreById(int theatreId)
        {
            return _theatreDbcontext.theatre.Find(theatreId);
        }

        public void UpdateTheatre(Theatre theatre)
        {
            _theatreDbcontext.Entry(theatre).State = EntityState.Modified;
            _theatreDbcontext.SaveChanges();
        }

        Theatre ITheatreRepository.GetTheatreById(int theatreId)
        {
            throw new NotImplementedException();
        }
    }
}
