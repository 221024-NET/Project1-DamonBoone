using Project1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Data
{
    internal interface TicketRepository
    {
        public bool createTicket(double amount, string description);
        public Ticket getAllTickets(int id);
    }
}
