using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace MovieAppLib.Models
{
    class SerialDeserial
    {
        public static void SerialiseData(List<Movie> movie)
        {
            File.WriteAllText("MovieData.json", JsonConvert.SerializeObject(movie));
        }

        public static List<Movie> DeserialiseData()
        {
            List<Movie> movie;
            string fileName = "MovieData.json";

            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                movie = JsonConvert.DeserializeObject<List<Movie>>(json);
                return movie;
            }
            else
            {
                File.WriteAllText("MovieData.json", "[]");
                string json = File.ReadAllText(fileName);
                movie = JsonConvert.DeserializeObject<List<Movie>>(json);
                return movie;
            }

        }
    }

}
