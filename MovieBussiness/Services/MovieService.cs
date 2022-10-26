using MovieData.Repository;
using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBussiness.Services
{
    public class MovieService
    {
        IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }



        //add Movie
        public void AddMovie(Movie movie)
        {
            _movieRepository.AddMovie(movie);
        }



        //update movie
        public void UpdateMovie(Movie movie)
        {
            _movieRepository.UpdateMovie(movie);
        }



        //delete movie
        public void DeleteMovie(int movieId)
        {
            _movieRepository.DeleteMovie(movieId);        }




        //get getmoviebyid
        public Movie GetMovieById(int movieId)
        {
            return _movieRepository.GetMovieById(movieId);
        }



        //get getmovies
        public IEnumerable<Movie> GetMovies()
        {
            return _movieRepository.GetMovies();
        }

    }
}
