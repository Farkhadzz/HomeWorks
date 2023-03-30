using GalaSoft.MvvmLight;
using StoreAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAdmin.Services.Interfaces
{
    public interface INavigationService
    {
        public void NavigateTo<T>(object? data = null) where T : ViewModelBase;
        public void NavigateDataTo<T>(object data) where T : ViewModelBase;
        //public void NavigateToBasket<T>(ProductModel product) where T : ViewModelBase;
    }
}
