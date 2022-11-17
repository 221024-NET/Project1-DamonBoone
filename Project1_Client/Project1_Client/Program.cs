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

            UserAccount a = AccountManager.getAccountAsync("login").GetAwaiter().GetResult();
            a.printAccountDetails();
            
        }



    }
}

