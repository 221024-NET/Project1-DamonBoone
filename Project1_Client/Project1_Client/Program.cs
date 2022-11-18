using Project1.App;
using Project1.Classes;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Project1_Client
{
    public class Program
    {
        static void Main()
        {
            UserAccount currentLogin = AccountManager.login().GetAwaiter().GetResult();
            currentLogin.printAccountDetails();

            if (currentLogin.role == "employee")
            {
                while (true)
                {
                    TicketManager.employeeMenu();
                }
            }
            else if (currentLogin.role == "manager")
            {
                while (true)
                {
                    TicketManager.managerMenu();
                }
            }

            //print tickets example
            //var pending = TicketManager.getPendingTicketsAsync().GetAwaiter().GetResult(); 
            //foreach(var b in pending)
            //{
            //    TicketManager.ShowTicket(b);
            //    
            //}


            //create account example
            //UserAccount acc = new UserAccount();
            //acc.email = "test5@example.com";
            //acc.password = "abc";
            //acc.role = "employee";

            //var a = AccountManager.CreateAccountAsync(acc).GetAwaiter().GetResult();
            //Console.WriteLine(a);


            //login example
            //UserAccount user = new UserAccount();
            //user.email = "test@test.com";
            //user.password = "pass";

            //UserAccount login = new UserAccount();
            //login = AccountManager.getAccountAsync(user).GetAwaiter().GetResult();
            //login.printAccountDetails();


            //update ticket example
            //Ticket a = new Ticket();
            //a.id = 7;
            //a.status = "approved";

            //TicketManager.updateTicketAsync(a).GetAwaiter().GetResult();



        }



    }
}

