using Project1.Classes;
using System;
namespace Project1.Data
{
    public interface IRepository
    {
        public UserAccount createAccount(string email, string password, string permissions);
    }
}