using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using StoreApp.Messages;
using StoreApp.Services.Interfaces;
using StoreApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Classes
{
    public class NavigationService : INavigationService
    {
        private readonly IMessenger _messenger;

        public NavigationService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void NavigateTo<T>(object? data = null) where T : ViewModelBase
        {
            _messenger.Send(new NavigationMessage()
            {
                ViewModelType = typeof(T)
            });

            if (data != null)
            {
                _messenger.Send(new DataMessage()
                {
                    Data = data
                });
            }
        }

        public void NavigateDataTo<T>(object data) where T : ViewModelBase
        {
            _messenger.Send(new DataMessage()
            {
                Data = data
            });
        }

        public void NavigateToBasket<T>(Product product) where T : ViewModelBase
        {
            _messenger.Send(new BasketMessage()
            {
                Product = product
            });
        }
    }
}
