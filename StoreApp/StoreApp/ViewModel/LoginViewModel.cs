using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.ViewModel
{
    internal class LoginViewModel
    {
        public IMessenger Messenger { get; set; } = new Messenger();
        public RelayCommand LoginCommand
        {
            get => new(() =>
            { 
                Messenger.Send(typeof(LoginViewModel));
            });
        }

        public RelayCommand RegisterCommand
        {
            get => new(() =>
            {
                Messenger.Send(typeof(RegistrationViewModel));
            });
        }
    }
}
