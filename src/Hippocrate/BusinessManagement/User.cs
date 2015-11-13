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
    }
}
