using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using StoreAdmin.Model;
using StoreAdmin.Services.Interfaces;
using StoreAdmin.Services.Messages;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace StoreAdmin.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessenger _messenger;
        private ViewModelBase _currentViewModel;

        public MainViewModel(INavigationService navigationService, IMessenger messenger)
        {
            CurrentViewModel = App.Container.GetInstance<AddViewModel>();

            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<NavigationMessage>(this, ReceiveNavigationMessage);
            _messenger.Register<DataMessage>(this, ReceiveDataMessage);
        }

        private ObservableCollection<ProductModel> _products = new();
        public ObservableCollection<ProductModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
            }
        }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                Set(ref _currentViewModel, value);
            }
        }

        public void ReceiveNavigationMessage(NavigationMessage message)
        {
            CurrentViewModel = App.Container.GetInstance(message.ViewModelType) as ViewModelBase;
        }

        public void MainOpen()
        {
            using FileStream fs = new(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString()).ToString() + "\\products.json", FileMode.OpenOrCreate, FileAccess.Read);
            using StreamReader sr = new(fs);

            fs.Position = 0;
            if (sr.ReadToEnd() != string.Empty)
            {
                fs.Position = 0;
                Products = JsonSerializer.Deserialize<ObservableCollection<ProductModel>>(sr.ReadToEnd());
            }
        }

        public void MainClose()
        {

            using FileStream fs = new(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString()).ToString() + "\\products.json", FileMode.Truncate, FileAccess.Write);
            using StreamWriter sw = new(fs);

            var json = JsonSerializer.Serialize(Products);

            sw.Write(json);
        }

        public RelayCommand AddCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<AddViewModel>();
            });
        }
        public void ReceiveDataMessage(DataMessage message)
        {
            ProductModel product = message.Data as ProductModel;
            Products.Add(product);
        }

    }
}
