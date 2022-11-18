using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Classes
{
    public class Ticket
    {
        public int id { get; set; }
        public double amount { get; set; }
        public string description { get; set; }
        public string status { get; set; }

        public Ticket(int id, double amount, string description, string status = "Pending")
        {
            this.id = id;
            this.amount = amount;
            this.description = description;
            this.status = status;
        }

        public Ticket(double amount, string description, string status = "Pending")
        {
            this.amount = amount;
            this.description = description;
            this.status = status;
        }

        public Ticket() { }

        public void printTicketDetails()
        {
            Console.WriteLine();
            Console.WriteLine("Information about this ticket: ");
            Console.WriteLine("ID: " + this.id);
            Console.WriteLine("Amount: " + this.amount);
            Console.WriteLine("Description: " + this.description);
            Console.WriteLine("Status: " + this.status);

        }
    }
}
