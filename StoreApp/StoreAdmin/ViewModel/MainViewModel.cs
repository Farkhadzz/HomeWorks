using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using StoreAdmin.Model;
using StoreAdmin.Services.Interfaces;
using StoreAdmin.Services.Messages;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAdmin.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        private ViewModelBase _currentViewModel;

        public MainViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
        }

        private ObservableCollection<ProductModel> _products = new();

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                Set(ref _currentViewModel, value);
            }
        }

        public void ReceiveNavigationMessage(NavigationMessage message)
        {
            CurrentViewModel = App.Container.GetInstance(message.ViewModelType) as ViewModelBase;
        }

    }
}
