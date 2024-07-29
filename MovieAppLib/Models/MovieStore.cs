using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAppLib.GlobalExceptionHandling;

namespace MovieAppLib.Models
{
    public class MovieStore
    {
        public static void MainMenu()
        {
            MovieManager.MovieListEmptyChecker();
            ChoiceMenu();
        }

        public static void ChoiceMenu()
        {
            int userChoice = 1;

            do
            {
                MovieManager.DotLinePrinter();
                Console.WriteLine("Welcome To Movie Store");

                userChoice = ChoiceMenuWhileLoop(userChoice);

                ChoiceMenuSwitch(userChoice);

                if (userChoice == 6)
                    break;

                Console.WriteLine("Press Enter to Continue!!");
            } while (true);

        }

        public static int ChoiceMenuWhileLoop(int userChoice)
        {
            while (true)
            {
                MovieManager.DotLinePrinter();
                Console.WriteLine("Choose and Enter Digit From Below");
                Console.WriteLine("1 -> To Get Movie Details by Id");
                Console.WriteLine("2 -> To Add a Movie");
                Console.WriteLine("3 -> To Remove a Movie");
                Console.WriteLine("4 -> To Update a Movie");
                Console.WriteLine("5 -> To Get Total Number of Movies");
                Console.WriteLine("6 -> To Exit");
                MovieManager.DotLinePrinter();



                try
                {
                    userChoice = int.Parse(Console.ReadLine());
                    if (userChoice < 1 || userChoice > 6)
                    {
                        throw new GlobalExceptionHandling.InvalidInputException("Invalid Input !");
                    }
                    return userChoice;
                }
                catch(InvalidInputException ex) 
                {
                        Console.WriteLine("Error :"+ex.Message);
                        continue;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error"+ e.Message);
                    continue;
                }

            }


        }

        public static void ChoiceMenuSwitch(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    MovieManager.DisplayMovie();
                    break;
                case 2:
                    try
                    {
                        MovieManager.Add();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error : " + e.Message);
                    }
                    break;
                case 3:
                    try
                    {
                        MovieManager.Remove();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error : " + e.Message);
                    }
                    break;
                case 4:
                    try
                    {
                        MovieManager.Update();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error : " + e.Message);
                    }
                    break;
                case 5:
                    MovieManager.MovieCount();
                    break;
                case 6:
                    break;

            }

        }


        //throw new GlobalExceptionHandling.MovieNotAddedException("Movie Adding Failed");

    }
}
