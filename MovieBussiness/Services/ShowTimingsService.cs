using MovieData.Repository;
using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBussiness.Services
{
    public class ShowTimingsService
    {
        IShowTimingsRepository _showTimingsRepository;
        public ShowTimingsService(IShowTimingsRepository showTimingsRepository)
        {
            _showTimingsRepository = showTimingsRepository;
        }



        //add showTimings
        public void AddShowTimings(ShowTimings showTimings)
        {
            _showTimingsRepository.AddShowTimings(showTimings);
        }



        //update showTimings
        public void UpdateShowTimings(ShowTimings showTimings)
        {
            _showTimingsRepository.UpdateShowTimings(showTimings);
        }



        //delete showTimings
        public void DeleteShowTimings(int showTimingsId)
        {
            _showTimingsRepository.DeleteShowTimings(showTimingsId);
        }




        //get getshowTimingsbyid
        public ShowTimings GetShowTimingsById(int showTimingsId)
        {
            return _showTimingsRepository.GetShowTimingsById(showTimingsId);
        }



        //get getshowTimings
        public IEnumerable<ShowTimings> GetShowTimings()
        {
            return _showTimingsRepository.GetShowTimings();
        }

    }
}
