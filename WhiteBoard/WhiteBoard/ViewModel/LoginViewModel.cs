using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WhiteBoard.Model;
using WhiteBoard.Services.Interfaces;
using WhiteBoard.View;

namespace WhiteBoard.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
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

        private bool _rememberMe;
        public bool RememberMe
        {
            get => _rememberMe;
            set
            {
                if (_rememberMe != value)
                {
                    _rememberMe = value;
                    RaisePropertyChanged();
                }
            }
        }

        private readonly INavigationService _navigationService;


        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand<PasswordBox> LoginCommand
        {
            get => new RelayCommand<PasswordBox>(
                async param =>
                {
                    try
                    {
                        var passwordBox = param as PasswordBox;
                        string password = passwordBox.Password;
                        string mail = Mail;

                        await Task.Run(() =>
                        {

                            using (var context = new UserContext())
                            {
                                var user = context.Users.FirstOrDefault(u => u.Mail == mail && u.Password == password);

                                if (user != null)
                                {
                                    MessageBox.Show("Login Successful !");
                                    user.RememberMe = RememberMe;
                                    context.SaveChangesAsync();
                                    _navigationService.NavigateTo<BoardViewModel>();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid User Data. Try Again !");
                                }
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.Message);
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
}
