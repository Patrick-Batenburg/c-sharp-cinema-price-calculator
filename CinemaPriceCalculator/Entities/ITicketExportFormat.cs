using System.Collections.Generic;

namespace CinemaPriceCalculator.Entities
{
    public interface ITicketExportFormat
    {
        void Export(int orderNumber, ICollection<MovieTicket> tickets);
    }
}
