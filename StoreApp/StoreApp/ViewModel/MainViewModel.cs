using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using StoreApp.Model;

namespace StoreApp.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        IMessenger Messenger = new Messenger();
        public ViewModelBase CurrentViewModel { get; set; } = new LoginViewModel();
    }
}
