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
        public UserAccount createAccount(string email, string password, string permissions)
        {
            //takes email, password, permissions as parameters
            //inserts them into database
            //selects the data from the database
            //creates new UserAccount object from the selected data
            //returns the object


            //creating and adding account to the database
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string cmdText = @"insert into Project1.UserAccount (email, password, permissions)
                             values (@email, @password, @permissions);";

            using SqlCommand command = new SqlCommand(cmdText, connection);

            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@permissions", permissions);

            command.ExecuteNonQuery();
            //finished adding to database

            //selecting from database and making a new object
            string cmdText2 = @"select accountID, email, password, permissions from Project1.UserAccount where email = @email;";
            using SqlCommand command2 = new SqlCommand(cmdText2, connection);
            command2.Parameters.AddWithValue("@email", email);
            using SqlDataReader reader = command2.ExecuteReader();

            UserAccount tmpAccount;

            while(reader.Read())
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
