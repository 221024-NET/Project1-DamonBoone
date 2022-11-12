using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class TicketIO
    {
        public TicketIO() { }

        public double getAmount()
        {
            double amount = 0;

            Console.WriteLine("Please enter the amount in USD: ");
            amount = Convert.ToDouble(Console.ReadLine());

            return amount;
        }
    }
}
