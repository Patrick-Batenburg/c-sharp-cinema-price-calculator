using CinemaPriceCalculator.Entities;
using System;
using Xunit;

namespace CinemaPriceCalculatorTest
{
    public class OrderTest
    {
        [Fact]
        public void Should_CalculatePrice_ForNormalTickets()
        {
            Movie movie = new Movie("The movie");
            MovieScreening movieScreening = new MovieScreening(movie, DateTime.Now, 2.00);
            MovieTicket movieTicket = new MovieTicket(movieScreening, TicketType.Normal, 1, 1);
            MovieTicket movieTicket1 = new MovieTicket(movieScreening, TicketType.Normal, 1, 1);
            MovieTicket movieTicket2 = new MovieTicket(movieScreening, TicketType.Normal, 1, 1);
            Order order = new Order(1);

            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket1);
            order.AddSeatReservation(movieTicket2);

            double actual = order.CalculatePrice();
            Assert.Equal(6, actual);
        }

        [Fact]
        public void Should_CalculatePrice_ForPremiumTickets()
        {
            Movie movie = new Movie("The movie");
            MovieScreening movieScreening = new MovieScreening(movie, DateTime.Now, 2.00);
            MovieTicket movieTicket = new MovieTicket(movieScreening, TicketType.Premium, 1, 1);
            MovieTicket movieTicket1 = new MovieTicket(movieScreening, TicketType.Premium, 1, 1);
            MovieTicket movieTicket2 = new MovieTicket(movieScreening, TicketType.Premium, 1, 1);
            Order order = new Order(1);

            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket1);
            order.AddSeatReservation(movieTicket2);

            double actual = order.CalculatePrice();
            Assert.Equal(15, actual);
        }

        [Fact]
        public void Should_CalculatePrice_ForStudentTickets()
        {
            Movie movie = new Movie("The movie");
            MovieScreening movieScreening = new MovieScreening(movie, new DateTime(2019, 1, 31), 2.00);
            MovieTicket movieTicket = new MovieTicket(movieScreening, TicketType.Student, 1, 1);
            Order order = new Order(1);

            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);

            double actual = order.CalculatePrice();
            Assert.Equal(4, actual);
        }

        [Fact]
        public void Should_CalculatePrice_ForGroupTicketsDuringWeekDays()
        {
            Movie movie = new Movie("The movie");
            MovieScreening movieScreening = new MovieScreening(movie, new DateTime(2019, 1, 31), 2.00);
            MovieTicket movieTicket = new MovieTicket(movieScreening, TicketType.Normal, 1, 1);
            Order order = new Order(1);

            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);

            double actual = order.CalculatePrice();
            Assert.Equal(10.8, actual);
        }

        [Fact]
        public void Should_CalculatePrice_ForGroupTicketsDuringWeekends()
        {
            Movie movie = new Movie("The movie");
            MovieScreening movieScreening = new MovieScreening(movie, new DateTime(2019, 2, 1), 2.00);
            MovieTicket movieTicket = new MovieTicket(movieScreening, TicketType.Normal, 1, 1);
            Order order = new Order(1);

            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);

            double actual = order.CalculatePrice();
            Assert.Equal(12, actual);
        }

        [Fact]
        public void Should_CalculatePrice_ForGroupStudentTicketsDuringWeekDays()
        {
            Movie movie = new Movie("The movie");
            MovieScreening movieScreening = new MovieScreening(movie, new DateTime(2019, 1, 31), 2.00);
            MovieTicket movieTicket = new MovieTicket(movieScreening, TicketType.Student, 1, 1);
            Order order = new Order(1);

            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);

            double actual = order.CalculatePrice();
            Assert.Equal(6, actual);
        }

        [Fact]
        public void Should_CalculatePrice_ForGroupStudentTicketsDuringWeekends()
        {
            Movie movie = new Movie("The movie");
            MovieScreening movieScreening = new MovieScreening(movie, new DateTime(2019, 2, 1), 2.00);
            MovieTicket movieTicket = new MovieTicket(movieScreening, TicketType.Student, 1, 1);
            Order order = new Order(1);

            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket);

            double actual = order.CalculatePrice();
            Assert.Equal(6, actual);
        }

        [Fact]
        public void Should_CalculatePrice_ForPremiumStudentTickets()
        {
            Movie movie = new Movie("The movie");
            MovieScreening movieScreening = new MovieScreening(movie, DateTime.Now, 2.00);
            MovieTicket movieTicket = new MovieTicket(movieScreening, TicketType.PremiumStudent, 1, 1);
            MovieTicket movieTicket1 = new MovieTicket(movieScreening, TicketType.PremiumStudent, 1, 1);
            MovieTicket movieTicket2 = new MovieTicket(movieScreening, TicketType.PremiumStudent, 1, 1);
            Order order = new Order(1);

            order.AddSeatReservation(movieTicket);
            order.AddSeatReservation(movieTicket1);
            order.AddSeatReservation(movieTicket2);

            double actual = order.CalculatePrice();
            Assert.Equal(8, actual);
        }
    }
}
