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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace StoreApp.ViewModel
{
    public class BasketViewModel : ViewModelBase, INotifyPropertyChanged, INotifyCollectionChanged
    {
        private float _total = 0;
        public float Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChange(nameof(Total));
            }
        }

        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        public CardModel Card { get; set; } = new();

        private readonly IMessenger _messenger;
        private readonly ISerializeService _serializeService;

        public void ReceiveBasketMessage(BasketMessage message)
        {
            bool key = false;

            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Name == message.Product.Name)
                {
                    Total += message.Product.Price;

                    key = true;
                }
            }

            if (key == false)
            {
                AddToBasket(message.Product);
            }
        }

        public BasketViewModel(IMessenger messenger, ISerializeService serializeService)
        {
            _messenger = messenger;
            _serializeService = serializeService;

            _messenger.Register<BasketMessage>(this, ReceiveBasketMessage);
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

        protected void AddToBasket(Product product)
        {
            Products.Add(product);
            Total += product.Price;

            OnCollectionChange(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, Products));
        }

        public RelayCommand<object> DeleteProductCommand
        {
            get => new(name =>
            {
                int i = 0;
                while (Products[i].Name != name)
                {
                    i++;
                }
                Products.RemoveAt(i);
            });
        }

        public RelayCommand MasterCardCommand
        {
            get => new(() =>
            {
                Card.CardType = CardTypes.MasterCard;
            });
        }

        public RelayCommand VisaCommand
        {
            get => new(() =>
            {
                Card.CardType = CardTypes.Visa;
            });
        }

        public RelayCommand AnotherCommand
        {
            get => new(() =>
            {
                Card.CardType = CardTypes.AnotherCard;
            });
        }

        public RelayCommand<object> IncreaseCommand
        {
            get => new(name =>
            {
                int i = 0;
                while (Products[i].Name != name)
                {
                    i++;
                }

                Total += Products[i].Price;

                OnCollectionChange(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, Products));
            });
        }

        public RelayCommand<object> DecreaseCommand
        {
            get => new(name =>
            {
                int i = 0;
                while (Products[i].Name != name)
                {
                    i++;
                }
            });
        }

        public RelayCommand CheckoutCommand
        {
            get => new(() =>
            {
                if (Products.Count >= 1 && Card != null && Total != 0 && Products != null && Card.CardNumber != null && Card.CardCVV != null)
                {
                    if (Card.CardNumber.Length == 16)
                    {
                        if (Card.CardCVV.Length == 3)
                        {
                            if (Card.CardExpireDate.Date != null)
                            {
                                MessageBox.Show("We sent Check to your Email address.", "Checkout Info", MessageBoxButton.OK, MessageBoxImage.Information);

                                var json = _serializeService.Serialize<ObservableCollection<Product>>(Products);

                                using FileStream fs = new("basket_data.json", FileMode.OpenOrCreate);
                                using StreamWriter sw = new(fs);
                                sw.Write(json);
                            }
                            else
                            {
                                MessageBox.Show("Card ExpireDate is Wrong", "Checkout Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Card CVV is Wrong", "Checkout Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Card Number is Wrong", "Checkout Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("There`re nothing in the Basket to Checkout or There some missing card info! Add something to Basket.", "Checkout Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
    }
}
