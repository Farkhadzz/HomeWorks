using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteBoard.Services.Interfaces;
using WhiteBoard.Messages;
using WhiteBoard.View;


namespace WhiteBoard.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        private readonly Services.Interfaces.INavigationService _navigationService;
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
        public MainViewModel(IMessenger messenger, Services.Interfaces.INavigationService navigationService)
        {
            CurrentViewModel = App.Container.GetInstance<LoginViewModel>();

            _messenger = messenger;
            _navigationService = navigationService;

            _messenger.Register<NavigationMessage>(this, ReceiveMessage);
        }

    }
}
