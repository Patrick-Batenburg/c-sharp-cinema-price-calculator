using System;
using System.Collections.Generic;
using System.Text;

namespace cinema_price_calculator
{
    public class Order
    {
        private List<MovieTicket> tickets;

        public Order(int orderNumber)
        {
            this.OrderNumber = orderNumber;
            tickets = new List<MovieTicket>();
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            tickets.Add(ticket);
        }

        public double CalculatePrice()
        {
            return 0;
        }

        public int OrderNumber { get; private set; }

        public void Export(TicketExportFormat exportFormat)
        {
            // Bases on the string respresentations of the tickets (toString), write
            // the ticket to a file with naming convention Order_<orderNr>.txt of
            // Order_<orderNr>.json
        }
    }

}
