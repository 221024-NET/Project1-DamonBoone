using Project1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                catch (System.FormatException ex)
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

        public int employeeMenu()
        {
            //check if the currently logged in account has the employee role
            //if they dont.. dont show this menu
            //enter 1 to create a new ticket
            //enter 2 to see all tickets
            int input = 0;
            bool keepGoing = true;
            while (keepGoing)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter the number corresponding with your menu slection.");
                    Console.WriteLine("1. Create a new ticket");
                    Console.WriteLine("2. View past tickets");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input == 1 || input == 2)
                    {
                        keepGoing = false;
                    }
                }
                catch (System.FormatException ex)
                {
                    Console.WriteLine("Error! Selection must be a number!");
                }
            }
            return input;
        }

        public string getNewStatus()
        {
            string status;

            Console.WriteLine("Please enter a new ticket status: ");
            status = Console.ReadLine();

            return status;
        }

        public int ticketToUpdate()
        {
            int ticketID = 0;
            bool keepGoing = true;
            while (keepGoing)
            {
                try
                {
                    Console.WriteLine("Enter the ID of the ticket you would like to update: ");
                    ticketID = Convert.ToInt32(Console.ReadLine());
                    if (ticketID > 0)
                    {
                        keepGoing = false;
                    }
                }
                catch (System.FormatException ex)
                {
                    Console.WriteLine("Error! Selection must be a number!");
                }
            }
            return ticketID;
        }
    }
}
