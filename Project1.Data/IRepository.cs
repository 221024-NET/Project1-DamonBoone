using Project1.Classes;
using System;
namespace Project1.Data
{
    public interface IRepository
    {
        public void createAccount(string email, string password, string permissions);
        public UserAccount getAccount(string email, string password);
    }
}