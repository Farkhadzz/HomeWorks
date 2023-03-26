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

namespace StoreApp.ViewModel
{
    internal class StoreViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public StoreViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand CustomersCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<CustomersViewModel>();
            });
        }
    }
}
