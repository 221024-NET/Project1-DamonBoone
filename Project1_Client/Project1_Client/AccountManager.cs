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

        public static async Task<UserAccount> login()
        {
            int menuSelection = UserIO.welcomeMessage();
            string email;
            string password;
            int roleNumber;
            string roleName;
            UserAccount account;

            //if they entered 1, log into existing account
            if (menuSelection == 1)
            {
                while (true)
                {
                    email = UserIO.getLoginEmail();
                    password = UserIO.getLoginPassword();
                    UserAccount temp = new UserAccount();
                    temp.email = email;
                    temp.password = password;
                    account = await getAccountAsync(temp);
                    //input validation...
                    if (account.email != null)
                    {
                        return account;
                    }
                    else
                    {
                        Console.WriteLine("That account does not exist or your password is wrong. Please try again.");
                        continue;
                    }
                }
            }
            //if they entered 2, create a new one
            else if (menuSelection == 2)
            {
                while (true)
                {
                    email = UserIO.getLoginEmail();
                    password = UserIO.getLoginPassword();
                    roleNumber = UserIO.getRole();
                    UserAccount temp = new UserAccount();
                    temp.email = email;
                    temp.password = password;
                    //user enters a number for a role, translate that number into a role manually
                    if (roleNumber == 1)
                    {
                        roleName = "employee";
                        temp.role = roleName;
                        var a = await createAccountAsync(temp);
                        account = await getAccountAsync(temp);
                        if(account.email == null)
                        {
                            Console.WriteLine("That email is already registered. Please enter a new email.");
                            continue;
                        }
                        return account;
                    }
                    else if (roleNumber == 2)
                    {
                        roleName = "manager";
                        temp.role = roleName;
                        var a = await createAccountAsync(temp);
                        account = await getAccountAsync(temp);
                        if (account.email == null)
                        {
                            Console.WriteLine("That email is already registered. Please enter a new email.");
                            continue;
                        }
                        return account;
                    }
                }
            }
            else
            {
                //input validation should avoid this ever happening...
                account = new();
                return account;
            }

        }

        //async create account method
        public static async Task<Uri> createAccountAsync(UserAccount user)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7021/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync("register", user);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
        //async login method
        public static async Task<UserAccount> getAccountAsync(UserAccount user)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7021/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync("login", user);
            user = await response.Content.ReadAsAsync<UserAccount>();
            return user;
        }
    }
}
