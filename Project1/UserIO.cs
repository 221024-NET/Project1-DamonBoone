using Project1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.App
{
    public class UserIO
    {

        public UserIO() { }
        //show inital prompt for user login
        //steps:
        //enter your username, or press 2 to make an account
        //if they enter user, ask for password
        //call getAccount method, if it cant find their account re-prompt
        //allow user to go back to making an account or try credentials again

        public int welcomeMessage()
        {
            int menuSelection = 0;
            bool keepGoing = true;

            while (keepGoing)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Welcome to the Ticket Management System.");
                    Console.WriteLine("Enter the number corresponding with your menu slection.");
                    Console.WriteLine("1. Login with existing account");
                    Console.WriteLine("2. Create new account");
                    menuSelection = Convert.ToInt32(Console.ReadLine());
                    //input validation...
                    if (menuSelection == 1 || menuSelection == 2)
                    {
                        keepGoing = false;
                    }
                }
                catch (System.FormatException ex)
                {
                    Console.WriteLine("Error! Selection must be a number!");
                }
            }
            return menuSelection;
        }

        public string getLoginEmail()
        {
            string email;
            
            Console.WriteLine("Please enter your email: ");
            email = Console.ReadLine();

            return email;
        }

        public string getLoginPassword()
        {
            string password;

            Console.WriteLine("Please enter your password: ");
            password = Console.ReadLine();

            return password;
        }

        public int getRole()
        {
            int role = 0;
            bool keepGoing = true;

            while(keepGoing)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter the number corresponding with your menu slection.");
                    Console.WriteLine("1. Employee");
                    Console.WriteLine("2. Manager");
                    role = Convert.ToInt32(Console.ReadLine());
                    //input validation...
                    if (role == 1 || role == 2)
                    {
                        keepGoing = false;
                    }
                }
                catch(System.FormatException ex)
                {
                    Console.WriteLine("Error! Selection must be a number!");
                }
            }
            return role;
        }


    }
}
