using Project1.Classes;
using Project1.Data;
using System;

namespace Project1.App
{
    class App
    {
        public static void Main(string[] args)
        {

            IRepository repo = new SqlRepository();
            AccountManager acc = new AccountManager(repo);

            //UserAccount a = acc.getAccount("test@test.com", "pass");

            //a.printAccountDetails();

            Console.WriteLine(repo.createAccount("test@blast.com", "pass", "employee"));

            //display welcome message and prompt user to enter email
            //if no email found, get email,password and pass them to createAccount method

            //if email is found, ask for password, then pass them to a login method

            //ALTERNATE
            //start with login method, ask for email
            //if email isnt found, call createAccount method
        }
    }
}

