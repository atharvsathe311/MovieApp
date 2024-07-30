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
        public void Add()
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

        public void Remove()
        {
            MovieListEmptyChecker();
            Console.WriteLine(".................. Remove Movie ..................");

            Console.WriteLine("Enter Movie Id to Remove");
            DotLinePrinter();
            string userChoiceMovieId = Console.ReadLine();
            DotLinePrinter();
            try
            {
                if (MovieRemover(movies, userChoiceMovieId))
                {
                    SuccessPrinter("Movie Removed Successfully");
                    SerialDeserial.SerialiseData(movies);
                    DotLinePrinter();
                    return;
                }
                throw new GlobalExceptionHandling.MovieNotFoundException("Movie Id doesnt Exist!");
            }
            catch(Exception e)
            {
                Console.Write("Error : "+e.Message);
            }
        }

        public bool MovieRemover(List<Movie> movies, string userChoiceMovieId)
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

        public void Update()
        {
            MovieListEmptyChecker();
            Console.WriteLine(".................. Update Movie ..................");
            Console.WriteLine("Enter Movie Id to Update");
            DotLinePrinter();
            string userChoiceMovieId = Console.ReadLine();
            DotLinePrinter();
            try
            {
                if (MovieUpdater(movies, userChoiceMovieId))
                {
                    SuccessPrinter("Movie Update Succesful");
                    SerialDeserial.SerialiseData(movies);
                    DotLinePrinter();
                    return;
                }
                throw new GlobalExceptionHandling.MovieNotFoundException("Movie Id doesnt Exist!");
            }
            catch(Exception e)
            {
                Console.WriteLine("Error :"+e.Message);
            }
        }

        public bool MovieUpdater(List<Movie> movies, string userChoiceMovieId)
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

        public void SuccessPrinter(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayMovie()
        {
            MovieListEmptyChecker();
            Console.WriteLine("............. Display Movie Details ..............");
            try
            {
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
            catch (Exception ex) 
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public bool MovieDisplayer(List<Movie> movies, string userChoiceMovieId)
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

        public void MovieListEmptyChecker()
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

        public void MovieCount()
        {
            DotLinePrinter();
            Console.WriteLine("The Total Count of Movies is : " + movies.Count);
            DotLinePrinter();
        }

        public void DotLinePrinter()
        {
            Console.WriteLine("..................................................");
        }



    }
}

