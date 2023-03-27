using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreApp.Model;
using StoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StoreApp.ViewModel;
    internal class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUserManageService _userManageService;

        public string Login { get; set; }

    public LoginViewModel(INavigationService navigationService, IUserManageService userManageService)
    {
        _navigationService = navigationService;
        _userManageService = userManageService;
    }

    public RelayCommand<object> LoginCommand
        {
            get => new(
                param =>
            {
                try
                {
                    var password = param as PasswordBox;

                    var user = _userManageService.GetUser(Login, password.Password);

                    MessageBox.Show($"{user.Mail} Logged In");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("User Doesn't Exists");
                }
            });
        }

        public RelayCommand RegisterCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<RegistrationViewModel>();
            });
        }
    }
