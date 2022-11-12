﻿using Project1.Classes;
using Project1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Project1.App
{
    public class AccountManager
    {
        AccountRepository repo;
        UserIO IO;

        public AccountManager(AccountRepository repo, UserIO IO)
        {
            this.repo = repo;
            this.IO = IO;
        }

        public UserAccount login()
        {
            int menuSelection = IO.welcomeMessage();
            string email;
            string password;
            int roleNumber;
            string roleName;
            UserAccount account;

            //if they entered 1, log into existing account
            if(menuSelection == 1)
            {
                email = IO.getLoginEmail();
                password = IO.getLoginPassword();
                account = repo.getAccount(email, password);
                return account;
            }
            //if they entered 2, create a new one
            else if(menuSelection == 2)
            {
                while (true)
                {
                    email = IO.getLoginEmail();
                    password = IO.getLoginPassword();
                    roleNumber = IO.getRole();

                    if (roleNumber == 1)
                    {
                        roleName = "employee";
                        if (repo.createAccount(email, password, roleName))
                        {
                            account = repo.getAccount(email, password);
                            return account;
                        }
                        else
                        {
                            Console.WriteLine("That account already exists! Try again.");
                            continue;
                        }
                    }
                    else if (roleNumber == 2)
                    {
                        roleName = "manager";
                        if (repo.createAccount(email, password, roleName))
                        {
                            account = repo.getAccount(email, password);
                            return account;
                        }
                        else
                        {
                            Console.WriteLine("That account already exists! Try again.");
                            continue;
                        }
                    }
                }
            }
            else
            {
                account = new();
                return account;
            }
            
        }

    }
}
