using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using StoreApp.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Classes
{
    internal class NavigationService : INavigationService
    {
        private readonly IMessenger _messenger;

        public NavigationService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void NavigateTo<T>() where T : ViewModelBase
        {
            _messenger.Send(new NavigationMessage()
            {
                ViewModelType = typeof(T)
            });
        }
    }
}
