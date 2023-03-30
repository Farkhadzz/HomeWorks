using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using StoreApp.Model;
using StoreApp.Services.Interfaces;
using StoreApp.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace StoreApp.ViewModel
{
    public class ProductViewModel : ViewModelBase, INotifyPropertyChanged, INotifyCollectionChanged
    {
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        private readonly IMessenger _messenger;
        private readonly ISerializeService _serializeService;
        private readonly INavigationService _myNavigationService;

        public ProductViewModel(IMessenger messenger, ISerializeService serializeService, INavigationService myNavigationService)
        {
            _messenger = messenger;
            _serializeService = serializeService;
            _myNavigationService = myNavigationService;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected void OnCollectionChange(NotifyCollectionChangedEventArgs e)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, e);
            }
        }

        public void StoreStartUp()
        {
            using FileStream fs = new(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString()).ToString() + "\\products.json", FileMode.Open, FileAccess.Read);
            using StreamReader sr = new(fs);

            fs.Position = 0;

            Products = JsonSerializer.Deserialize<ObservableCollection<Product>>(sr.ReadToEnd());
        }

        public RelayCommand<object> AddCommand
        {
            get => new(name =>
            {
                for (int i = 0; i < Products.Count; i++)
                {
                    if (Products[i].Name == name)
                    {
                        _myNavigationService.NavigateToBasket<BasketViewModel>(Products[i]);

                        MessageBox.Show($"{name} is Added To Cart", "Cart Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            });
        }
    }
}
