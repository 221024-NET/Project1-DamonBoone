using Project1.Classes;
using Project1.Data;
using System;

namespace Project1
{
    class App
    {
        public static void Main(string[] args)
        {
            //testing connection string
            string connectionString = File.ReadAllText("F:/Revature/Project1/connectionString.txt");
            Console.WriteLine(connectionString);

            IRepository repo = new SqlRepository();
            UserAccount user = repo.createAccount("abc@123.com", "password", "employee");

            user.printAccountDetails();

            //display welcome message and prompt user to enter email
            //if no email found, get email,password and pass them to createAccount method

            //if email is found, ask for password, then pass them to a login method

            //ALTERNATE
            //start with login method, ask for email
            //if email isnt found, call createAccount method
        }
    }
}

