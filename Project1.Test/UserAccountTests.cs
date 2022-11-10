using Moq;
using Project1.App;
using Project1.Classes;
using Project1.Data;


namespace Project1.Test
{
    public class UserAccountTests
    {
        [Fact]
        public void UserAccount_getAccount()
        {
            Mock<IRepository> mockRepo = new();
            UserAccount expectedAccount = new UserAccount(1, "test@123.com", "password", "employee");

            mockRepo.Setup(x => x.getAccount("test123.com", "password")).Returns(new UserAccount(1, "test@123.com", "password", "employee"));

            AccountManager temp = new AccountManager(mockRepo.Object);
            UserAccount user = temp.getAccount("test123.com", "password");
            
            
            
            Assert.Equal(expectedAccount, user);
            /*actual should be the account that is returned from mock method*/
        }
    }
}