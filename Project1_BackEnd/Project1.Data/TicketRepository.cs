using Project1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Data
{
    public interface TicketRepository
    {
        public bool createTicket(double amount, string description);
        public List<Ticket> getAllTickets();
        public List<Ticket> getPendingTickets();
        public void updateTicketStatus(int id, Ticket ticket);
    };
}
