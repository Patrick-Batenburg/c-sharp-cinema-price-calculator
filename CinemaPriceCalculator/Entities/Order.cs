using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CinemaPriceCalculator.Entities
{
    public class Order
    {
        private List<MovieTicket> tickets;

        public Order(int orderNumber)
        {
            this.OrderNumber = orderNumber;
            tickets = new List<MovieTicket>();
        }
        public int OrderNumber { get; private set; }


        public void AddSeatReservation(MovieTicket ticket)
        {
            tickets.Add(ticket);
        }

        public double CalculatePrice()
        {
            bool isWeekDay = false;
            double ticketPrice = 0;
            double totalPrice = 0;
            int numberOfStudentTickets = 0;
            int numberOfPremiumStudentTickets = 0;
            int numberOfNormalTickets = 0;
            int numberOfPremiumTickets = 0;
            DateTime dateTime = DateTime.Now;

            if (tickets.Count > 0)
            {
                dateTime = tickets[0].MovieScreening.dateAndTime;
                ticketPrice = tickets[0].Price;
            }

            foreach (MovieTicket ticket in tickets)
            {
                switch (ticket.Type)
                {
                    case TicketType.Normal:
                        numberOfNormalTickets++;
                        break;
                    case TicketType.Premium:
                        numberOfPremiumTickets++;
                        break;
                    case TicketType.Student:
                        numberOfStudentTickets++;
                        break;
                    case TicketType.PremiumStudent:
                        numberOfPremiumStudentTickets++;
                        break;
                    default:
                        throw new Exception("Ticket type not supported.");
                }
            }

            //2nd ticket free for students
            numberOfStudentTickets = (numberOfStudentTickets / 2) + (numberOfStudentTickets % 2);
            numberOfPremiumStudentTickets = (numberOfPremiumStudentTickets / 2) + (numberOfPremiumStudentTickets % 2);

            //2nd ticket free on weekdays
            if (dateTime.DayOfWeek < DayOfWeek.Friday && dateTime.DayOfWeek != DayOfWeek.Sunday)
            {
                totalPrice += (numberOfNormalTickets / 2) + (numberOfNormalTickets % 2);
                totalPrice += (numberOfPremiumTickets / 2) + (numberOfPremiumTickets % 2);
                isWeekDay = true;
            }

            //calculate totals including premium costs
            double totalStudentPrice = ((numberOfStudentTickets + numberOfPremiumStudentTickets) * ticketPrice) + (numberOfPremiumStudentTickets * 2);
            double totalNormalPrice = ((numberOfNormalTickets + numberOfPremiumTickets) * ticketPrice) + (numberOfPremiumTickets * 3);

            if (isWeekDay && numberOfNormalTickets + numberOfPremiumTickets >= 6)
            {
                totalNormalPrice *= 0.9;
            }

            totalPrice = totalNormalPrice + totalStudentPrice;
            return totalPrice;
        }

        public void Export(ITicketExportFormat exportFormat)
        {
            exportFormat.Export(this.OrderNumber, tickets);
        }
    }
}
