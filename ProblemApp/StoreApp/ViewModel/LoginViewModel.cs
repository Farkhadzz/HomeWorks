using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using StoreApp.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.ViewModel
{
    internal class LoginViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;

        public LoginViewModel(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public RelayCommand LoginCommand
        {
            get => new(() =>
            { 

            });
        }

        public RelayCommand RegisterCommand
        {
            get => new(() =>
            {
                //_messenger.Send<NavigationMessage>(new()
                //{
                //    ViewModelType = (typeof(RegistrationViewModel))
                //});

                _messenger.Send(new NavigationMessage() { ViewModelType = typeof(RegistrationViewModel) });
                
            });
        }
    }
}
