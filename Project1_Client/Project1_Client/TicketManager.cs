using Project1;
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
            client = new HttpClient();
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

        public static async Task<List<Ticket>> getPendingTicketsAsync()
        {
            client = new HttpClient();
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
            client = new HttpClient();
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
        public static async Task<Uri> createTicketAsync(Ticket ticket)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7021/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync("createticket", ticket);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public static void employeeMenu()
        {
            int input = TicketIO.employeeMenu();
            if (input == 1)
            {
                //amount
                //description
                Ticket ticket = new Ticket();
                ticket.amount = TicketIO.getAmount();
                ticket.description = TicketIO.getDescription();
                createTicketAsync(ticket).GetAwaiter().GetResult();
            }
            else if (input == 2)
            {
                List<Ticket> list = new List<Ticket>();
                list = getAllTicketsAsync().GetAwaiter().GetResult();
                foreach(Ticket t in list)
                {
                    t.printTicketDetails();
                }
            }
        }

        public static void managerMenu()
        {
            int input = TicketIO.managerMenu();
            if (input == 1)
            {
                List<Ticket> list = new List<Ticket>();
                list = getPendingTicketsAsync().GetAwaiter().GetResult();
                if (list.Count == 0)
                {
                    Console.WriteLine("There are currently no pending tickets.");
                    return;
                }
                foreach (Ticket t in list)
                {
                    t.printTicketDetails();
                }
                int updateID = TicketIO.ticketToUpdate();
                string newStatus = TicketIO.getNewStatus();
                Ticket temp = new Ticket();
                temp.id = updateID;
                temp.status = newStatus;
                updateTicketAsync(temp).GetAwaiter().GetResult();
            }
        }
    }
}
