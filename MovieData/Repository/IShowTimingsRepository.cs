using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieData.Repository
{
    public interface IShowTimingsRepository    
    {     
            void AddShowTimings(ShowTimings showTimings);
            void UpdateShowTimings(ShowTimings showTimings);
            void DeleteShowTimings(ShowTimings showTimings);
            ShowTimings GetShowTimingsById(int showTimingsId);
            IEnumerable<ShowTimings> GetShowTimings();
            void DeleteShowTimings(int showTimingsId);
    }
}
