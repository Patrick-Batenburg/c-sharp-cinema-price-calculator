using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CinemaPriceCalculator.Entities
{
    class TicketExportToJson : ITicketExportFormat
    {
        public void Export(int orderNumber, ICollection<MovieTicket> tickets)
        {
            string jsonPath = $@"c:\temp\Order_{orderNumber}.json";

            //serialize object directly into file stream
            using (StreamWriter file = File.CreateText(jsonPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, tickets);
            }       
        }
    }
}
