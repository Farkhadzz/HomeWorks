using System;
using StoreApp.Services.Classes;
using StoreApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StoreApp.Model;
using System.Windows.Controls;

namespace StoreApp.ViewModel;
internal class RegistrationViewModel : ViewModelBase
{
    public User User { get; set; } = new();

    private readonly INavigationService _navigationService;
    private readonly IUserManageService _userService;

    public RegistrationViewModel(INavigationService navigationService, IUserManageService userService)
    {
        _navigationService = navigationService;
        _userService = userService;
    }

    public RelayCommand LoginCommand
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<LoginViewModel>();
        });

    }

    public RelayCommand<object> RegistrationCommand
    {
        get => new(
            param =>
        {
        if (param != null)
        {
            object[] res = (object[])param;

            var password = (PasswordBox)res[0];
            var confirm = (PasswordBox)res[1];

            var checker = new PasswordService(password, confirm);

                if (checker.IsMatch() && !_userService.CheckExists(User.Login, password.Password))
                {
                    User.Password = password.Password;
                    User.ConfirmPassword = confirm.Password;

                    _userService.Add(User);
                } 
                else
                {
                    MessageBox.Show("Null");
                }
            }
        });
        
    }
}
