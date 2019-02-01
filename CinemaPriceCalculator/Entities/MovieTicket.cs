namespace CinemaPriceCalculator.Entities
{
    public class MovieTicket
    {
        public MovieTicket(MovieScreening movieScreening, TicketType type, int seatRow, int seatNumber)
        {
            this.MovieScreening = movieScreening;
            this.Type = type;
            this.SeatRow = seatRow;
            this.SeatNumber = seatNumber;
            this.Price = movieScreening.PricePerSeat;
        }

        public int SeatRow { get; private set; }

        public int SeatNumber { get; private set; }

        public double Price { get; private set; }

        public TicketType Type { get; private set; }

        public MovieScreening MovieScreening { get; private set; }

        public override string ToString()
        {
            return $"{MovieScreening.ToString()} - row {SeatRow}, seat {SeatNumber} {(Type == TicketType.Premium ? " (Premium)" : (Type == TicketType.PremiumStudent ? " (Premium)" : "") )}";
        }
    }

}
