using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using StoreApp.Services.Classes;
using StoreApp.View;
using StoreApp.ViewModel;
using StoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StoreApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; } = new();

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();

            var store = App.Container.GetInstance<ProductViewModel>();
            store.StoreStartUp();

            MainStartup();

            base.OnStartup(e);
        }

        private void Register()
        {
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationService, NavigationService>();
            Container.RegisterSingleton<IUserManageService, UserManageService>();
            Container.RegisterSingleton<ISerializeService, SerializeService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<HomeViewModel>();
            Container.RegisterSingleton<LoginViewModel>();
            Container.RegisterSingleton<RegistrationViewModel>();
            Container.RegisterSingleton<StoreViewModel>();
            Container.RegisterSingleton<CustomersViewModel>();
            Container.RegisterSingleton<ProductViewModel>();
            Container.RegisterSingleton<BasketViewModel>();
        }
        private void MainStartup()
        {
            var mainView = new MainView();
            mainView.DataContext = Container?.GetInstance<MainViewModel>();
            mainView.ShowDialog();
        }
    }
}
