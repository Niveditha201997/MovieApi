using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieData.Repository
{
    public interface ITheatreRepository
    {
        void AddTheatre(Theatre theatre);
        void UpdateTheatre(Theatre theatre);
        void DeleteTheatre(Theatre theatre);
        Theatre GetTheatreById(int theatreId);
        IEnumerable<Theatre> GetTheatre();
        void DeleteTheatre(int theatreId);
    }
}
