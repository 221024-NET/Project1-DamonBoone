using Project1.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Data
{
    public class SqlRepository : IRepository
    {
        string connectionString = File.ReadAllText("F:/Revature/Project1/connectionString.txt");
        public bool createAccount(string email, string password, string permissions)
        {
            //takes email, password, permissions as parameters
            //inserts them into database

            //to check if user already exists:
            //perform a select command, loop thru db with a reader
            //if reader finds the username, return false


            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //checking if username exists
            string checkUser = @"select email from Project1.UserAccount where email = @email;";
            using SqlCommand checkUserCommand = new SqlCommand(checkUser, connection);
            checkUserCommand.Parameters.AddWithValue("@email", email);
            using SqlDataReader reader = checkUserCommand.ExecuteReader();

            while(reader.Read())
            {
                return false;
            }
            reader.Close();

            //if we're here it means the username doesnt exist; safe to make the account
            //creating and adding account to the database
            string cmdText = @"insert into Project1.UserAccount (email, password, permissions)
                             values (@email, @password, @permissions);";

            using SqlCommand command = new SqlCommand(cmdText, connection);

            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@permissions", permissions);


            command.ExecuteNonQuery();
            //finished adding to database
            
            connection.Close();

            return true;
        }

        public UserAccount getAccount(string email, string password)
        {
            //selects the data from the database
            //creates new UserAccount object from the selected data
            //returns the object

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //selecting from database and making a new object
            string cmdText = @"select accountID, email, password, permissions from Project1.UserAccount where email = @email and password = @password;";
            using SqlCommand command = new SqlCommand(cmdText, connection);

            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);

            using SqlDataReader reader = command.ExecuteReader();

            UserAccount tmpAccount;

            while (reader.Read())
            {
                //                                      accountID           email                  password         permissions   
                return tmpAccount = new UserAccount(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            }
            connection.Close();
            //finish selecting from database

            UserAccount noAccount = new();
            return noAccount;
        }
    }
}
