using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppLib.Models
{
    class MovieManager
    {
        private static List<Movie> movies;
        public MovieManager() 
        {
             movies = SerialDeserial.DeserialiseData();
        }
        public static void Add()
        {
            Console.WriteLine(".................. Adding Movie ..................");
            Console.WriteLine("Enter Movie Name");
            string movieName = Console.ReadLine();
            Console.WriteLine("Enter Movie Genre");
            string movieGenre = Console.ReadLine();
            Console.WriteLine("Enter Movie Release Year");
            int movieYear = int.Parse(Console.ReadLine());

            Movie movie = new Movie(movieName, movieGenre, movieYear);
            movies.Add(movie);
            SerialDeserial.SerialiseData(movies);
        }

        public static void Remove()
        {
            MovieListEmptyChecker();
            Console.WriteLine(".................. Remove Movie ..................");

            Console.WriteLine("Enter Movie Id to Remove");
            DotLinePrinter();
            string userChoiceMovieId = Console.ReadLine();
            DotLinePrinter();
            if (MovieRemover(movies, userChoiceMovieId))
            {
                SuccessPrinter("Movie Removed Successfully");
                SerialDeserial.SerialiseData(movies);
                DotLinePrinter();
                return;
            }
            throw new GlobalExceptionHandling.MovieNotFoundException("Movie Id doesnt Exist!");
        }

        public static bool MovieRemover(List<Movie> movies, string userChoiceMovieId)
        {
            for (int iterator = 0; iterator < movies.Count; iterator++)
            {
                Movie account = movies[iterator];
                if (movies[iterator].id == userChoiceMovieId)
                {
                    movies.RemoveAt(iterator);
                    return true;
                }
            }
            return false;

        }

        public static void Update()
        {
            MovieListEmptyChecker();
            Console.WriteLine(".................. Update Movie ..................");
            Console.WriteLine("Enter Movie Id to Update");
            DotLinePrinter();
            string userChoiceMovieId = Console.ReadLine();
            DotLinePrinter();
            if (MovieUpdater(movies, userChoiceMovieId))
            {
                SuccessPrinter("Movie Update Succesful");
                SerialDeserial.SerialiseData(movies);
                DotLinePrinter();
                return;
            }
            throw new GlobalExceptionHandling.MovieNotFoundException("Movie Id doesnt Exist!");
        }

        public static bool MovieUpdater(List<Movie> movies, string userChoiceMovieId)
        {

            for (int iterator = 0; iterator < movies.Count; iterator++)
            {
                Movie movie = movies[iterator];
                if (movie.id == userChoiceMovieId)
                {
                    Console.WriteLine("Enter Choice for Updating Value");
                    Console.WriteLine("1.Movie Name\n2.Movie Genre\n3.Year of Release");
                    int userUpdateChoice = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Value");
                    string valueToUpdate = Console.ReadLine();
                    switch (userUpdateChoice)
                    {
                        case 1:
                            movie.Name = valueToUpdate;
                            movie.IdCreator();
                            Console.WriteLine("Movie Updated Successfully");
                            return true;
                        case 2:
                            movie.Genre = valueToUpdate;
                            movie.IdCreator();
                            Console.WriteLine("Movie Updated Successfully");
                            return true;
                        case 3:
                            movie.Year = int.Parse(valueToUpdate);
                            movie.IdCreator();
                            Console.WriteLine("Movie Updated Successfully");
                            return true;

                    }
                }
            }
            return false;

        }

        public static void SuccessPrinter(string message)
        {
            Console.WriteLine(message);
        }

        public static void DisplayMovie()
        {
            MovieListEmptyChecker();
            Console.WriteLine("............. Display Movie Details ..............");

            Console.WriteLine("Enter the Movie Id");
            DotLinePrinter();
            string userChoiceMovieId = Console.ReadLine();
            DotLinePrinter();
            if (MovieDisplayer(movies, userChoiceMovieId))
            {
                DotLinePrinter();
                return;
            }
            throw new GlobalExceptionHandling.MovieNotFoundException("Movie Id doesnt Exist!");

        }

        public static bool MovieDisplayer(List<Movie> movies, string userChoiceMovieId)
        {
            for (int iterator = 0; iterator < movies.Count; iterator++)
            {
                Movie account = movies[iterator];
                if (movies[iterator].id == userChoiceMovieId)
                {
                    Console.WriteLine("Movie Id is : " + movies[iterator].id);
                    Console.WriteLine("Movie Name is : " + movies[iterator].Name);
                    Console.WriteLine("Movie Genre is : " + movies[iterator].Genre);
                    Console.WriteLine("Movie Year of Release is : " + movies[iterator].Year);
                    return true;
                }
            }
            return false;

        }

        public static void MovieListEmptyChecker()
        {
            List<Movie> movie = SerialDeserial.DeserialiseData();
            try
            {
                if (movie.Count == 0)
                {
                    throw new GlobalExceptionHandling.NoMovieExistException("No Movies Exist Please Add the Movies :");
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                Add();
            }
        }

        public static void MovieCount()
        {
            DotLinePrinter();
            Console.WriteLine("The Total Count of Movies is : " + movies.Count);
            DotLinePrinter();
        }

        public static void DotLinePrinter()
        {
            Console.WriteLine("..................................................");
        }



    }
}

