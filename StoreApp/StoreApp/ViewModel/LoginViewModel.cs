using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreApp.Messages;
using StoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.ViewModel;
    internal class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public LoginViewModel(INavigationService navigationService)
        {
        _navigationService = navigationService;
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

                _navigationService.NavigateTo<RegistrationViewModel>();
            });
        }
    }
