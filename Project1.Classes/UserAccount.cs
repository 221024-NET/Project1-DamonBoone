namespace Project1.Classes
{
    public class UserAccount
    { 
        string email { get; set; }
        string password { get; set; }
        string permissions { get; set; } //either employee or manager

        public UserAccount(string email, string password, string permissions)
        {
            this.email = email;
            this.password = password;
            this.permissions = permissions;
        }
    }
}