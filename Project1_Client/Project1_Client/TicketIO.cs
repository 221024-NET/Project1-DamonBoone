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
        public static double getAmount()
        {
            double amount = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter the amount in USD: ");
                    amount = Convert.ToDouble(Console.ReadLine());
                }
                catch (System.FormatException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error! Amount must be a number with up to 2 decimal places.");
                    Console.WriteLine();
                    continue;
                }
                return amount;
            }
        }

        public static string getDescription()
        {
            string description = "";
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a description: ");
                description = Console.ReadLine();
                if (description.Length > 0)
                {
                    keepGoing = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Error! No description entered. Please try again.");
                    Console.WriteLine();
                }
            }
            return description;
        }

        public static int employeeMenu()
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
                    Console.WriteLine("3. Quit application");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input == 1 || input == 2)
                    {
                        keepGoing = false;
                    }
                    else if(input == 3)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error! Selection is not included in the menu.");
                        Console.WriteLine();
                    }
                }
                catch (System.FormatException ex)
                {
                    Console.WriteLine("Error! Selection must be a number!");
                }
            }
            return input;
        }

        public static int managerMenu()
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
                    Console.WriteLine("1. Update an existing ticket");
                    Console.WriteLine("2. Quit application");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input == 1)
                    {
                        keepGoing = false;
                    }
                    else if(input == 2)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error! Selection is not included in the menu.");
                        Console.WriteLine();
                    }
                }
                catch (System.FormatException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error! Selection must be a number!");
                    Console.WriteLine();
                }
            }
            return input;
        }

        public static int getNewStatus()
        {
            int newStatus = 0;
            bool keepGoing = true;

            while (keepGoing)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Select the new status for the ticket.");
                    Console.WriteLine("1. Approve");
                    Console.WriteLine("2. Deny");
                    newStatus = Convert.ToInt32(Console.ReadLine());
                    //input validation...
                    if (newStatus == 1 || newStatus == 2)
                    {
                        keepGoing = false;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error! Selection is not included in the menu.");
                        Console.WriteLine();
                    }
                }
                catch (System.FormatException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error! Selection must be a number!");
                    Console.WriteLine();
                }
            }
            return newStatus;
        }

        public static int ticketToUpdate()
        {
            int ticketID = 0;
            bool keepGoing = true;
            while (keepGoing)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter the ID of the ticket you would like to update: ");
                    ticketID = Convert.ToInt32(Console.ReadLine());
                    if (ticketID > 0)
                    {
                        keepGoing = false;
                    }
                }
                catch (System.FormatException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error! Selection must be a number!");
                    Console.WriteLine();
                }
            }
            return ticketID;
        }
    }
}
