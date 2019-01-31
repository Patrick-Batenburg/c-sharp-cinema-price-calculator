namespace cinema_price_calculator
{
    public class MovieTicket
    {
        public MovieScreening movieScreening;

        public MovieTicket(MovieScreening movieScreening, TicketType type, int seatRow, int seatNumber)
        {
            this.movieScreening = movieScreening;
            this.Type = type;
            this.SeatRow = seatRow;
            this.SeatNumber = seatNumber;
            this.Price = movieScreening.PricePerSeat;
        }

        public int SeatRow { get; private set; }

        public int SeatNumber { get; private set; }

        public double Price { get; private set; }

        public TicketType Type { get; set; }

        public override string ToString()
        {
            return $"{movieScreening.ToString()} - row {SeatRow}, seat {SeatNumber} {(Type == TicketType.Premium ? " (Premium)" : (Type == TicketType.PremiumStudent ? " (Premium)" : "") )}";
        }
    }

}
