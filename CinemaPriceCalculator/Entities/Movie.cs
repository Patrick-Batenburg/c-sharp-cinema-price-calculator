using System.Collections.Generic;

namespace CinemaPriceCalculator.Entities
{
    public class Movie
    {
        private List<MovieScreening> screenings;

        public Movie(string title)
        {
            this.Title = title;

            screenings = new List<MovieScreening>();
        }

        public void AddScreening(MovieScreening screening)
        {
            screenings.Add(screening);
        }

        public string Title { get; set; }
    }
}
