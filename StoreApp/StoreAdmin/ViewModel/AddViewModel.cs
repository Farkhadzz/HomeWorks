using StoreAdmin.Model;
using StoreAdmin.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StoreAdmin.ViewModel
{
    public class AddViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ProductModel Product { get; set; } = new();


        public AddViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand ImagePickCommand
        {
            get => new(() =>
            {
                var dialog = new OpenFileDialog();
                dialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.jfif";

                var result = dialog.ShowDialog();
                if (result == true)
                {
                    Product.ProductImage = (string)dialog.FileName;
                }
            });
        }

        public RelayCommand AcceptCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateDataTo<MainViewModel>(Product);
            });
        }
    }
}
