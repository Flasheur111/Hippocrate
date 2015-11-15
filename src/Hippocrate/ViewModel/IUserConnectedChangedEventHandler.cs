using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hippocrate.ViewModel
{
    interface IUserConnectedChangedEventHandler
    {
        void UserConnectedChangedEventHandler(object sender, ServiceUser.User e);
    }
}
