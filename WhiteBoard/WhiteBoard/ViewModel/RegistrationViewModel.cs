using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteBoard.View;
using WhiteBoard.ViewModel;
using WhiteBoard.Services.Classes;
using WhiteBoard.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WhiteBoard.Model;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Controls;
using System.Security;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace WhiteBoard.ViewModel
{
    public class RegistrationViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private string _mail;
        public string Mail
        {
            get => _mail;
            set
            {
                if (_mail != value)
                {
                    _mail = value;
                    RaisePropertyChanged();
                }
            }
        }
        public RegistrationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
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
            async param =>
            {
                if (param != null)
                {
                    
                    object[] res = (object[])param;
                    
                    var password = (PasswordBox)res[0];
                    var confirm = (PasswordBox)res[1];

                    var checker = new PasswordService(password, confirm);

                        if (checker.IsMatch())
                        {
                            await Task.Run(() =>
                            {
                                using (var context = new UserContext())
                                {
                                    var user = new User
                                    {
                                        Mail = Mail,
                                        Password = password.Password,
                                        ConfirmPass = confirm.Password
                                    };

                                    context.Users.Add(user);
                                    var save = context.SaveChanges();
                                    if (save > 0)
                                    {
                                        MessageBox.Show("Registration Has Been Successfully Completed !");
                                    }
                                }
                            });
                        }
                        else
                        {
                            MessageBox.Show("Invalid User Data. Try Again !");
                        }
                }
            });
        }
    }
}
