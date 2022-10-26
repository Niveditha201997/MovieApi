using MovieEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace MovieData.Repository
{
    public interface IMovieRepository
    {
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(Movie movie);
        Movie GetMovieById(int movieId);
        IEnumerable<Movie> GetMovies();
        void DeleteMovie(int movieId);
    }
}
