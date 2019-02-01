using System;

namespace CinemaPriceCalculator.Entities
{
    public class MovieScreening
    {
        private Movie movie;

        // LocalDate date = LocalDate.of(2000, Month.NOVEMBER, 20);
        public DateTime dateAndTime { get; private set; }

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            this.movie = movie;
            movie.AddScreening(this);

            this.dateAndTime = dateAndTime;
            this.PricePerSeat = pricePerSeat;
        }

        public double PricePerSeat { get; private set; }

        public override string ToString()
        {
            return $"{movie.Title} {dateAndTime}";
        }
    }
}
