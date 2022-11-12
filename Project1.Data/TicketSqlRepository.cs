using Project1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Data
{
    public class TicketSqlRepository : TicketRepository
    {
        string connectionString = File.ReadAllText("F:/Revature/Project1/connectionString.txt");

        public bool createTicket(double amount, string description)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> getAllTickets()
        {
            throw new NotImplementedException();
        }

        public List<Ticket> getPendingTickets()
        {
            throw new NotImplementedException();
        }
    }
}
