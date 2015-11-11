using Hippocrate.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
