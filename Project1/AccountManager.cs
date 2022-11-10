using Project1.Classes;
using Project1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.App
{
    public class AccountManager
    {
        IRepository repo;

        public AccountManager(IRepository repo)
        {
            this.repo = repo;
        }

        public UserAccount getAccount(string email, string password)
        {
            UserAccount account = repo.getAccount(email, password);
            return account;
        }
    }
}
