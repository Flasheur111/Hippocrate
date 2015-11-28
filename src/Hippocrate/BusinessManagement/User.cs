using Hippocrate.DataAccess;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;

namespace Hippocrate.BusinessManagement
{
    public static class User
    {
        public static bool Connect(string login, string pass)
        {
            try
            {
                ServiceUserManager sum = new ServiceUserManager();
                return sum.Connect(login, pass);
            }
            catch (EndpointNotFoundException e)
            {
                MessageBox.Show("Le serveur ne répond pas.", "Erreur");
                return false;
            }
        }

        public static ServiceUser.User GetUser(string login)
        {
            try
            {
                ServiceUserManager sum = new ServiceUserManager();
                return sum.GetUser(login);
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Le serveur ne répond pas.", "Erreur");
                return null;
            }
        }

        public static ServiceUser.User[] GetUserList()
        {
            try
            {
                ServiceUserManager sum = new ServiceUserManager();
                return sum.GetListUser();
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Le serveur ne répond pas.", "Erreur");
                return null;
            }
        }

        public static bool DeleteUser(string login)
        {
            try
            {
                ServiceUserManager sum = new ServiceUserManager();
                return sum.DeleteUser(login);
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Le serveur ne répond pas.", "Erreur");
                return false;
            }
        }

        public static bool AddUser(ServiceUser.User user)
        {
            try
            {
                ServiceUserManager sum = new ServiceUserManager();
                return sum.AddUser(user);
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Le serveur ne répond pas.", "Erreur");
                return false;
            }
        }
    }
}
