using Project1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.App
{
    public class TicketManager
    {
        TicketRepository repo;

        public TicketManager(TicketRepository repo)
        {
            this.repo = repo;
        }
    }
}
