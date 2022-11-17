using Project1.Classes;
using Project1.Data;
using System;

namespace Project1.App
{
    class App
    {
        public static void Main(string[] args)
        {

            AccountRepository repo = new AccountSqlRepository();
            UserIO IO = new UserIO();
            AccountManager acc = new AccountManager(repo, IO);

            TicketRepository trepo = new TicketSqlRepository();
            TicketIO tIO = new TicketIO();
            TicketManager tm = new TicketManager(trepo, tIO);


            
            UserAccount currentUser = acc.login();
            currentUser.printAccountDetails();
            if(currentUser.role == "employee")
            {
                tm.employeeMenu();
            }

            //if(currentUser.role == "employee")
            //{
            //    tm.printAllTickets();
            //}

            

            
            //for employees:
            //show a menu where they can select either create a new ticket or view past history of tickets

            //for managers:
            //get pending tickets from db and put them into a list
            //show the manager the list
            //allow them to select a ticket and change its status
            //upon status change, update the ticket in the db and remove it from the pending list



            //Console.WriteLine(repo.createAccount("test@blast.com", "pass", "manager"));

            //display welcome message and prompt user to enter email
            //if no email found, get email,password and pass them to createAccount method

            //if email is found, ask for password, then pass them to a login method

            //ALTERNATE
            //start with login method, ask for email
            //if email isnt found, call createAccount method
        }
    }
}

