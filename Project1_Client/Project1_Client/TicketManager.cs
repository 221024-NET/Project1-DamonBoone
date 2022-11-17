using Project1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Client
{
    public class TicketManager
    {
        public static HttpClient client = new HttpClient();

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

        public static async Task<List<Ticket>> getPendingTicketsAsync()
        {
            client.BaseAddress = new Uri("https://localhost:7021/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            List<Ticket> ticketList = new List<Ticket>();
            var path = "getpendingtickets";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                ticketList = await response.Content.ReadAsAsync<List<Ticket>>();
            }

            return ticketList;
        }

        //update ticket
        public static async Task<Ticket> updateTicketAsync(Ticket ticket)
        {
            client.BaseAddress = new Uri("https://localhost:7021/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"updateticketstatus/{ticket.id}", ticket);
            response.EnsureSuccessStatusCode();

            ticket = await response.Content.ReadAsAsync<Ticket>();
            return ticket;
        }

        //create ticket
    }
}
