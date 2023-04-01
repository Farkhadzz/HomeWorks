using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreApp.Services.Classes;
using StoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using StoreApp.Model;
using GalaSoft.MvvmLight.Messaging;
using StoreApp.Messages;

namespace StoreApp.ViewModel
{
    internal class CustomersViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        public User User { get; set; } = new();


        public void ReceiveMessage(DataMessage message)
        {
            User = message.Data as User;
        }
        public CustomersViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<DataMessage>(this, ReceiveMessage);
        }

     
    }
}
