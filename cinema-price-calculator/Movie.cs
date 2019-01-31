using System;
using System.Collections.Generic;
using System.Text;

namespace cinema_price_calculator
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
