using Project1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Project1.App
{
    public class AccountManager
    {
        public static HttpClient client = new HttpClient();
        UserIO IO;

        public AccountManager( UserIO IO)
        {
            this.IO = IO;
        }

        //public UserAccount login()
        //{
        //    int menuSelection = IO.welcomeMessage();
        //    string email;
        //    string password;
        //    int roleNumber;
        //    string roleName;
        //    UserAccount account;

        //    //if they entered 1, log into existing account
        //    if (menuSelection == 1)
        //    {
        //        while (true)
        //        {
        //            email = IO.getLoginEmail();
        //            password = IO.getLoginPassword();
        //            account = repo.getAccount(email, password);
        //            //input validation...
        //            if (account.email != null)
        //            {
        //                return account;
        //            }
        //            else
        //            {
        //                Console.WriteLine("That account does not exist or your password is wrong. Please try again.");
        //                continue;
        //            }
        //        }
        //    }
        //    //if they entered 2, create a new one
        //    else if (menuSelection == 2)
        //    {
        //        while (true)
        //        {
        //            email = IO.getLoginEmail();
        //            password = IO.getLoginPassword();
        //            roleNumber = IO.getRole();
        //            //user enters a number for a role, translate that number into a role manually
        //            if (roleNumber == 1)
        //            {
        //                roleName = "employee";
        //                if (repo.createAccount(email, password, roleName)) //this returns true if the account was succesfully created, false otherwise
        //                {
        //                    account = repo.getAccount(email, password);
        //                    return account;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("That account already exists! Try again.");
        //                    continue;
        //                }
        //            }
        //            else if (roleNumber == 2)
        //            {
        //                roleName = "manager";
        //                if (repo.createAccount(email, password, roleName))
        //                {
        //                    account = repo.getAccount(email, password);
        //                    return account;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("That account already exists! Try again.");
        //                    continue;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //input validation should avoid this ever happening...
        //        account = new();
        //        return account;
        //    }

        //}

        //async create account method
        public static async Task<Uri> CreateAccountAsync(UserAccount user)
        {
            client.BaseAddress = new Uri("https://localhost:7021/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync("register", user);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
        //async login method
        public static async Task<UserAccount> getAccountAsync(string path) //idk what this path is
        {
            client.BaseAddress = new Uri("https://localhost:7021/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            UserAccount account = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if(response.IsSuccessStatusCode)
            {
                account = await response.Content.ReadAsAsync<UserAccount>();
            }
            return account;
        }
    }
}
