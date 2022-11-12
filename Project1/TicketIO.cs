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

            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the amount in USD: ");
                    amount = Convert.ToDouble(Console.ReadLine());
                }
                catch(System.FormatException ex)
                {
                    Console.WriteLine("Error! Amount must be a number with up to 2 decimal places.");
                    continue;
                }
                return amount;
            }
        }

        public string getDescription()
        {
            string description;

            Console.WriteLine("Please enter a description: ");
            description = Console.ReadLine();

            return description;
        }
    }
}
