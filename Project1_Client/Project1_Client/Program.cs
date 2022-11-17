using Project1.Classes;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace a
{
    public class Program
    {
        public static HttpClient client = new HttpClient();
        static void Main()
        {
            var a = getAllTicketsAsync().GetAwaiter().GetResult(); 
            foreach(var b in a)
            {
                ShowTicket(b);
            }
        }

        public static async Task<List<Ticket>> getAllTicketsAsync()
        {
            client.BaseAddress = new Uri("https://localhost:7021/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            List<Ticket> ticketList = new List<Ticket>();
            var path = "gettickets";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                ticketList = await response.Content.ReadAsAsync<List<Ticket>>();
            }

            return ticketList;
        }

        public static void ShowTicket(Ticket ticket)
        {
            ticket.printTicketDetails();
        }

    }
}

