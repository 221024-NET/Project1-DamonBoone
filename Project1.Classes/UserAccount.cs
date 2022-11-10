namespace Project1.Classes
{
    public class UserAccount
    {
        int id {get; set;}
        string email { get; set; }
        string password { get; set; }
        string permissions { get; set; } //either employee or manager

        public UserAccount(int id, string email, string password, string permissions)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.permissions = permissions;
        }

        public UserAccount() { }

        public void printAccountDetails()
        {
            Console.WriteLine(this.id);
            Console.WriteLine(this.email);
            Console.WriteLine(this.password);
            Console.WriteLine(this.permissions);
        }
    }
}