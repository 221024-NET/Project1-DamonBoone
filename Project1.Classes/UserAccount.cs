﻿using System.Text;

namespace Project1.Classes
{
    public class UserAccount
    {
        int id {get; set;}
        string email { get; set; }
        string password { get; set; }
        string role { get; set; } //either employee or manager

        public UserAccount(int id, string email, string password, string permissions)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.role = permissions;
        }

        public UserAccount() { }

        public void printAccountDetails()
        {
            StringBuilder hiddenPassword = new StringBuilder();
            
            foreach (char c in this.password)
            {
                 hiddenPassword.Append("*");
            }
            Console.WriteLine();
            Console.WriteLine("Welcome!");
            Console.WriteLine("Your ID is: " + this.id);
            Console.WriteLine("Your email is: " + this.email);
            Console.WriteLine("Your password is: " + hiddenPassword);
            Console.WriteLine("Your role is: " + this.role);
        }
    }
}