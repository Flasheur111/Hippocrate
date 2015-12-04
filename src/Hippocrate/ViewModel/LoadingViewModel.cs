using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hippocrate.ViewModel
{
    public class LoadingViewModel : ViewModelBase
    {
        private bool _loading;

        public bool Loading
        {
            get
            {
                return _loading;
            }
            set
            {
                if (_loading != value)
                {
                    _loading = value;
                    RaisePropertyChanged("Loading");
                }
            }
        }

    }
}
