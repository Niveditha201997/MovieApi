//using System;
//using System.Collections.Generic;
//using System.Text;
//using MovieEntity.Models;
//using MovieData;

//namespace MoviePresentation
//{
//    public class MoviePL
//    {
//        public void AddMovie()
//        {
//            MovieOperations movieOperations = new MovieOperations();
//            Movie movie = new Movie();            
//            Console.WriteLine("Enter FoodCategoryId : ");
//            movie.Name = Console.ReadLine();
//            Console.WriteLine("Enter Movie Description : ");
//            movie.MovieDesc = Console.ReadLine();
//            Console.WriteLine("Enter Movie Type : ");
//            movie.MovieType = Console.ReadLine();
//            string msg = movieOperations.AddMovie(movie);
//            Console.WriteLine(msg);
//        }
//        public void ShowAllMovie()
//        {
//            MovieOperations movieOperations = new MovieOperations();
//            List<Movie> movies = movieOperations.ShowAll();
//            foreach (var item in movies)
//            {
//                Console.WriteLine("Id : " + item.Id);
//                Console.WriteLine("Name : " + item.Name);
//                Console.WriteLine("Description : " + item.MovieDesc);
//                Console.WriteLine("Type : " + item.MovieType);
//            }
//        }
//        public void UpdateMovie()
//        {
//            MovieOperations movieOperations = new MovieOperations();
//            Movie movie = new Movie();
//            Console.WriteLine("Enter MovieName : ");
//            movie.Name = Console.ReadLine();
//            Console.WriteLine("Enter Movie Description : ");
//            movie.MovieDesc = Console.ReadLine();
//            Console.WriteLine("Enter Movie Type : ");
//            movie.MovieType = Console.ReadLine();
//            string msg = movieOperations.UpdateMovie(movie);
//            Console.WriteLine(msg);
//        }
//        public void DeleteMovie()
//        {
//            MovieOperations movieOperations = new MovieOperations();
//            Movie movie = new Movie();            
//            Console.WriteLine("Movie Id : ");
//            movie.Id = Convert.ToInt32(Console.ReadLine());
//            string msg = movieOperations.DeleteMovie(movie);
//            Console.WriteLine(msg);
//        }
//        private void GetMovieMenu()
//        {
//            Console.WriteLine("1) Press 1 to add a Movie\n" +
//                "2) Press 2 to show all movie\n" +
//                "3) Press 3 to update a movie\n" +
//                "4) Press 4 to delete a movie\n" +
//                "5) Press 5 to exit");
//        }
//        public void MovieSection()
//        {
//            Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine("Welcome-to-Movie-Section-------------");
//            Console.ForegroundColor = ConsoleColor.White;
//            bool bookLoop = true;
//            while (bookLoop == true)
//            {

//                GetMovieMenu();
//                int bookCase = int.Parse(Console.ReadLine());
//                switch (bookCase)
//                {
//                    case 1:
//                        AddMovie();
//                        break;
//                    case 2:
//                        ShowAllMovie();
//                        break;
//                    case 3:
//                        UpdateMovie();
//                        break;
//                    case 4:
//                        DeleteMovie();
//                        break;
//                    case 5:
//                        Console.WriteLine("");
//                        bookLoop = false;
//                        break;
//                    default:
//                        Console.ForegroundColor = ConsoleColor.Red;
//                        Console.WriteLine("Invalid input!!!");
//                        Console.ForegroundColor = ConsoleColor.White;
//                        break;
//                }
//            }
//        }
//    }
//}
