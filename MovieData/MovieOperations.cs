using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieEntity.Models;
using System.Linq;

namespace MovieData
{
    public class MovieOperations
    {
        AllDbContext db = null;
        public MovieOperations(AllDbContext db)
        {
            this.db = db;
        }
        public string AddMovie(Movie movie)
        {
            db = new AllDbContext();
            db.movies.Add(movie);
            db.SaveChanges();
            return "Saved";
        }
        public string UpdateMovie(Movie movie)
        {
            db = new AllDbContext();
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated";
        }
        public string DeleteMovie(Movie movieId)
        {
            db = new AllDbContext();
            Movie movieobj = db.movies.Find(movieId);
            db.Entry(movieobj).State = EntityState.Deleted;
            db.SaveChanges();
            return "Deleted";
        }
        public List<Movie> ShowAll()
        {
            db = new AllDbContext();
            List<Movie> movieList = db.movies.ToList();
            return movieList;
        }
        //public List<Movie> ShowAllByMovieType(string type)
        //{
        //    db = new AllDbContext();
        //    List<Movie> movieList = db.movies.ToList();

            //Linq query-select * from movie where movietype='type'
            //var result = from movies in movieList
            //             where movies.MovieType == type
            //              select movies;
                         //select new Movie
                         //{
                         //    Id = movies.Id,
                         //    Name = movies.Name,
                         //};

        //    List<Movie> movieResult = new List<Movie>();
        //    foreach (var item in result) //Linq query execution
        //    {
        //        movieList.Add(item);
        //    }
        //    return movieResult;
        //}   
        public Movie ShowMovieById(int movieId)
        {
            db = new AllDbContext();
            Movie movie = db.movies.Find(movieId);
            return new Movie();
        }
    }
}
