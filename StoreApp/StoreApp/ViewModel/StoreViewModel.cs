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
using StoreApp.Messages;
using StoreApp.Model;
using GalaSoft.MvvmLight.Messaging;

namespace StoreApp.ViewModel
{
    internal class StoreViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        public User User { get; set; } = new();


        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                Set(ref _currentViewModel, value);
            }
        }
        public StoreViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<DataMessage>(this, ReceiveMessage);
        }

        public RelayCommand CustomersCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<CustomersViewModel>();
            });
        }

        public void ReceiveMessage(DataMessage message)
        {
            User = message.Data as User;
        }
    }
}
