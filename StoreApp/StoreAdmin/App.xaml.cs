using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using StoreAdmin.ViewModel;
using StoreAdmin.Services.Classes;
using StoreAdmin.Services.Interfaces;
using StoreAdmin.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StoreAdmin
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
            MainStartup();
        }

        private void Register()
        {
            Container.RegisterSingleton<IMessenger, Messenger>();

            Container.RegisterSingleton<INavigationService, NavigationService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<AddViewModel>();
        }

        private void MainStartup()
        {
            var mainView = new MainWindowView();
            mainView.DataContext = Container.GetInstance<MainViewModel>();
            mainView.ShowDialog();
        }
    }
}
