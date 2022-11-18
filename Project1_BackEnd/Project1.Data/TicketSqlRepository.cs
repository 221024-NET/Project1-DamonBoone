using Project1.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Data
{
    public class TicketSqlRepository : TicketRepository
    {
        string connectionString = File.ReadAllText("F:/Revature/Project1/Project1_BackEnd/connectionString.txt");

        public bool createTicket(double amount, string description)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //checking for duplicate ticket
            string checkTicket = @"select amount, description from Project1.Ticket where amount = @amount and description = @description;";
            using SqlCommand checkTicketCommand = new SqlCommand(checkTicket, connection);
            checkTicketCommand.Parameters.AddWithValue("@amount", amount);
            checkTicketCommand.Parameters.AddWithValue("@description", description);
            using SqlDataReader reader = checkTicketCommand.ExecuteReader();

            while(reader.Read())
            {
                return false;
            }
            reader.Close();

            //creating and adding new ticket to db
            string newTicket = @"insert into Project1.Ticket (amount, description, status)
                               values (@amount, @description, 'pending');";
            using SqlCommand newTicketCommand = new SqlCommand(newTicket, connection);
            newTicketCommand.Parameters.AddWithValue("@amount", amount);
            newTicketCommand.Parameters.AddWithValue("@description", description);
            newTicketCommand.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public List<Ticket> getAllTickets()
        {
            List<Ticket> allTickets = new List<Ticket>();

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string findAllTickets = @"select ticketID, amount, description, status from Project1.Ticket;";
            using SqlCommand allTicketsCommand = new SqlCommand(findAllTickets, connection);
            using SqlDataReader reader = allTicketsCommand.ExecuteReader();

            while(reader.Read())
            {
                //amount is stored in the db as a decimal type, have to convert it to double for the ticket class
                double amount = Convert.ToDouble(reader.GetDecimal(1)); 
                allTickets.Add(new Ticket(reader.GetInt32(0), amount, reader.GetString(2), reader.GetString(3)));
            }

            connection.Close();
            return allTickets;
        }

        public List<Ticket> getPendingTickets()
        {
            List<Ticket> pendingTickets = new List<Ticket>();

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string findPendingTickets = @"select ticketID, amount, description, status from Project1.Ticket where status = 'pending';";
            using SqlCommand pendingTicketsCommand = new SqlCommand(findPendingTickets, connection);
            using SqlDataReader reader = pendingTicketsCommand.ExecuteReader();

            while (reader.Read())
            {
                //amount is stored in the db as a decimal type, have to convert it to double for the ticket class
                double amount = Convert.ToDouble(reader.GetDecimal(1));
                pendingTickets.Add(new Ticket(reader.GetInt32(0), amount, reader.GetString(2), reader.GetString(3)));
            }

            connection.Close();
            return pendingTickets;
        }

        public void updateTicketStatus(int ticketID, string newStatus)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string update = @"update Project1.Ticket set status = @newStatus where ticketID = @ticketID;";
            using SqlCommand updateCommand = new SqlCommand(update, connection);
            updateCommand.Parameters.AddWithValue("@newStatus", newStatus);
            updateCommand.Parameters.AddWithValue("@ticketID", ticketID);
            using SqlDataReader reader = updateCommand.ExecuteReader();

            connection.Close();
        }
    }
}
