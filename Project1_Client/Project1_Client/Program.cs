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
            //var pending = TicketManager.getPendingTicketsAsync().GetAwaiter().GetResult(); 
            //foreach(var b in pending)
            //{
            //    TicketManager.ShowTicket(b);
            //    TicketManager.updateTicketAsync(b).GetAwaiter().GetResult();
            //}

            UserAccount acc = new UserAccount();
            acc.email = "test@example.com";
            acc.password = "abc";
            acc.role = "employee";

            var a = AccountManager.CreateAccountAsync(acc).GetAwaiter().GetResult();
            Console.WriteLine(a);
            
        }



    }
}

