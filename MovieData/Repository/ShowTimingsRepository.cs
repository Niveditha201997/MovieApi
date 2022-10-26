using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore;

namespace MovieData.Repository
{
    public class ShowTimingsRepository : IShowTimingsRepository
    {

        AllDbContext _showTimingsDbcontext;
        public ShowTimingsRepository(AllDbContext showTimingsDbcontext)
        {
            _showTimingsDbcontext = showTimingsDbcontext;
        }
        public void AddShowTimings(ShowTimings showTimings)
        {
            _showTimingsDbcontext.showTimings.Add(showTimings);
            _showTimingsDbcontext.SaveChanges();
        }

        public void DeleteShowTimings(ShowTimings showTimings)
        {
            throw new NotImplementedException();
        }

        public void DeleteShowTimings(int showTimingsId)
        {
            var showTimings = _showTimingsDbcontext.showTimings.Find(showTimingsId);
            _showTimingsDbcontext.showTimings.Remove(showTimings);
            _showTimingsDbcontext.SaveChanges();
        }

        public IEnumerable<ShowTimings> GetShowTimings()
        {
            return _showTimingsDbcontext.showTimings.ToList();
        }

        public ShowTimings GetShowTimingsById(int showTimingsId)
        {
            return _showTimingsDbcontext.showTimings.Find(showTimingsId);
        }

        public void UpdateShowTimings(ShowTimings showTimings)
        {
            _showTimingsDbcontext.Entry(showTimings).State = EntityState.Modified;
            _showTimingsDbcontext.SaveChanges();
        }
    }
}
