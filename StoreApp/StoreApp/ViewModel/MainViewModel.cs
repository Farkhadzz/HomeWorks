using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
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
using StoreApp.Messages;
using StoreApp.Model;
using StoreApp.Services.Interfaces;

namespace StoreApp.ViewModel;
    class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;


    private ViewModelBase _currentViewModel;
    public ViewModelBase CurrentViewModel 
        { 
          get => _currentViewModel;
            set
            {
               Set(ref _currentViewModel, value);
            }
        }
        

    public void ReceiveMessage(NavigationMessage message)
    {
        CurrentViewModel = App.Container.GetInstance(message.ViewModelType) as ViewModelBase;
    }
    public MainViewModel(IMessenger messenger, INavigationService navigationService)
    {
            CurrentViewModel = App.Container.GetInstance<LoginViewModel>();

            _messenger = messenger;
            _navigationService = navigationService;

        _messenger.Register<NavigationMessage>(this, ReceiveMessage);
    }

    public RelayCommand StoreCommand
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<StoreViewModel>();
        });
    }

}


