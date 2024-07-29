namespace MovieAppLib.Models
{
    public class Movie
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public string id;

        public void IdCreator()
        {
            string idNameParameter = Name.Substring(0, 2);
            string idGenreParameter = Genre.Substring(0, 2);
            string idYearParameter = Year.ToString().Substring(2, 2);
            id = idNameParameter + idGenreParameter + idYearParameter;
        }

        public Movie() { }
        public Movie(string name, string genre, int year)
        {
            Name = name;
            Genre = genre;
            Year = year;
            IdCreator();
        }

        



    }
}
