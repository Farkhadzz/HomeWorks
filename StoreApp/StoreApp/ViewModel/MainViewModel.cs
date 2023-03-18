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

namespace StoreApp.ViewModel;
    class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel 
        { 
          get => _currentViewModel;
            set
            {
               Set(ref _currentViewModel, value);
            }
        }
        private readonly IMessenger _messenger;

    public void ReceiveMessage(NavigationMessage message)
    {
        CurrentViewModel = App.Container.GetInstance(message.ViewModelType) as ViewModelBase;
    }
    public MainViewModel(IMessenger messenger)
        {
            CurrentViewModel = App.Container.GetInstance<LoginViewModel>();

            _messenger = messenger;

        _messenger.Register<NavigationMessage>(this, ReceiveMessage);
        }
    }
