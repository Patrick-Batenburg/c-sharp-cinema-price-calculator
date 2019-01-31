using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
            double ticketPrice = 0;
            double totalPrice = 0;
            int numberOfStudents = 0;
            int numberOfStudentPremium = 0;
            int numberOfNormal = 0;
            int numberOfNormalPremium = 0;
            DateTime dateTime = DateTime.Now;

            foreach (var ticket in tickets)
            {
                dateTime = ticket.movieScreening.dateAndTime;
                ticketPrice = ticket.Price;

                switch (ticket.Type)
                {
                    case TicketType.Student:
                        numberOfStudents++;
                        break;
                    case TicketType.PremiumStudent:
                        numberOfStudentPremium++;
                        break;
                    case TicketType.Premium:
                        numberOfNormalPremium++;
                        break;
                    default:
                        numberOfNormal++;
                        break;
                }
            }
           
            //2nd ticket free for students
            numberOfStudents = (numberOfStudents / 2) + (numberOfStudents % 2);
            numberOfStudentPremium = (numberOfStudentPremium / 2) + (numberOfStudentPremium % 2);

            //2nd ticket free on weekdays
            if (dateTime.DayOfWeek == DayOfWeek.Monday ||
                dateTime.DayOfWeek == DayOfWeek.Tuesday ||
                dateTime.DayOfWeek == DayOfWeek.Wednesday ||
                dateTime.DayOfWeek == DayOfWeek.Thursday)
            {
                numberOfNormal = (numberOfNormal / 2) + (numberOfNormal % 2);
                numberOfNormalPremium = (numberOfNormalPremium / 2) + (numberOfNormalPremium % 2);
            }
            
            //calculate totals including premium costs
            double totalStudentPrice = ((numberOfStudents + numberOfStudentPremium) * ticketPrice) + (numberOfStudentPremium * 2);
            double totalNormalPrice = ((numberOfNormal + numberOfNormalPremium) * ticketPrice) + (numberOfNormalPremium * 3);

            if ((dateTime.DayOfWeek == DayOfWeek.Friday ||
                dateTime.DayOfWeek == DayOfWeek.Saturday ||
                dateTime.DayOfWeek == DayOfWeek.Sunday) &&
                numberOfNormal + numberOfNormalPremium >= 6
                )
            {
                totalNormalPrice = totalNormalPrice * 0.9;
            }

            totalPrice = totalNormalPrice + totalStudentPrice;
            return totalPrice;
        }

        public int OrderNumber { get; private set; }

        public void Export(TicketExportFormat exportFormat)
        {
            // Bases on the string respresentations of the tickets (toString), write
            // the ticket to a file with naming convention Order_<orderNr>.txt of
            // Order_<orderNr>.json
            string txtPath = $@"c:\temp\Order_{this.OrderNumber}.txt";
            string jsonPath = $@"c:\temp\Order_{this.OrderNumber}.json";

            if (exportFormat == TicketExportFormat.Plaintext)
            {
                foreach (MovieTicket ticket in tickets)
                {
                    if (!File.Exists(txtPath))
                    {
                        //Create file to write to
                        string createText = "Tickets:" + Environment.NewLine;
                        File.WriteAllText(txtPath, createText);
                    }

                    //add tickets to created file
                    string appendText = ticket.ToString() + Environment.NewLine;
                    File.AppendAllText(txtPath, appendText);
                }
            }
            else if (exportFormat == TicketExportFormat.Json)
            {
                //serialize object directly into file stream
                using (StreamWriter file = File.CreateText(jsonPath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, tickets);
                }
            }
        }
    }

}
