using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using StoreAdmin.Model;
using StoreAdmin.Services.Interfaces;
using StoreAdmin.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAdmin.Services.Classes
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

        public void NavigateChangeTo<T>(object data) where T : ViewModelBase
        {
            _messenger.Send(new ChangeMessage()
            {
                ChangeData = data
            });
        }

        public void NavigateDeleteTo<T>(object data) where T : ViewModelBase
        {
            _messenger.Send(new DeleteMessage()
            {
                DeleteData = data
            });
        }
    }
}
