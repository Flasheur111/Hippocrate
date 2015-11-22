using Hippocrate.DataAccess;
using System.Threading.Tasks;

namespace Hippocrate.BusinessManagement
{
    public static class User
    {
        public static Task<bool> ConnectAsync(string login, string pass)
        {
            ServiceUserManager sum = new ServiceUserManager();
            return sum.ConnectAsync(login, pass);
        }

        public static Task<ServiceUser.User> GetUserAsync(string login)
        {
            ServiceUserManager sum = new ServiceUserManager();
            return sum.GetUserAsync(login);
        }

        public static ServiceUser.User[] GetUserList()
        {
            ServiceUserManager sum = new ServiceUserManager();
            return sum.GetListUser();
        }

        public static bool DeleteUser(string login)
        {
            ServiceUserManager sum = new ServiceUserManager();
            return sum.DeleteUser(login);
        }

        public static bool AddUser(ServiceUser.User user)
        {
            ServiceUserManager sum = new ServiceUserManager();
            return sum.AddUser(user);
        }
    }
}
