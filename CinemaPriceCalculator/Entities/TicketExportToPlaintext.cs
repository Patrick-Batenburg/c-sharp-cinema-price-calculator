using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CinemaPriceCalculator.Entities
{
    public class TicketExportToPlaintext : ITicketExportFormat
    {
        public void Export(int orderNumber, ICollection<MovieTicket> tickets)
        {
            string txtPath = $@"c:\temp\Order_{orderNumber}.txt";

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
    }
}
