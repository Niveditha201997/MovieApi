using MovieData.Repository;
using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBussiness.Services
{
    public class TheatreService
    {
        ITheatreRepository _theatreRepository;
        public TheatreService(ITheatreRepository theatreRepository)
        {
            _theatreRepository = theatreRepository;
        }



        //add Theatre
        public void AddTheatre(Theatre theatre)
        {
            _theatreRepository.AddTheatre(theatre);
        }



        //update theatre
        public void UpdateTheatre(Theatre theatre)
        {
            _theatreRepository.UpdateTheatre(theatre);
        }



        //delete theatre
        public void DeleteTheatre(int theatreId)
        {
            _theatreRepository.DeleteTheatre(theatreId);
        }




        //get gettheatrebyid
        public Theatre GetTheatreById(int theatreId)
        {
            return _theatreRepository.GetTheatreById(theatreId);
        }



        //get gettheatre
        public IEnumerable<Theatre> GetTheatre()
        {
            return _theatreRepository.GetTheatre();
        }
    }
}
