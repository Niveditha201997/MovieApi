using System;
using System.Collections.Generic;
using System.Text;
using MovieEntity.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace MovieData.Repository
{
    public class MovieRepository : IMovieRepository
    {
        AllDbContext _movieDbcontext;
        public MovieRepository(AllDbContext movieDbcontext)
        {
            _movieDbcontext = movieDbcontext;
        }
        public void AddMovie(Movie movie)
        {
            _movieDbcontext.movies.Add(movie);
            _movieDbcontext.SaveChanges();
        }
        public void DeleteMovie(int movieId)
        {
            var movie = _movieDbcontext.movies.Find(movieId);
            _movieDbcontext.movies.Remove(movie);
            _movieDbcontext.SaveChanges();
        }

        public void DeleteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int movieId)
        {
            return _movieDbcontext.movies.Find(movieId);
        }
        public IEnumerable<Movie> GetMovies()
        {
            return _movieDbcontext.movies.ToList();
        }
        public void UpdateMovie(Movie movie)
        {
            _movieDbcontext.Entry(movie).State = EntityState.Modified;
            _movieDbcontext.SaveChanges();
        }       
    }
}
