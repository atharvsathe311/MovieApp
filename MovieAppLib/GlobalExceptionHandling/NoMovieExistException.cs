using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAppLib.Models;

namespace MovieAppLib.GlobalExceptionHandling
{
    public class NoMovieExistException:Exception
    {
        public NoMovieExistException(string message):base(message) 
        {
        }
    }
}
