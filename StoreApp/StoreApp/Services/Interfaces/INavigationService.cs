using GalaSoft.MvvmLight;
using StoreApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Interfaces
{
    public interface INavigationService
    {
        public void NavigateTo<T>(object? data = null) where T : ViewModelBase;
        public void NavigateDataTo<T>(object data) where T : ViewModelBase;
        public void NavigateToBasket<T>(Product product) where T : ViewModelBase;
    }
}
