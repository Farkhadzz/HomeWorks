using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using StoreApp.View;
using StoreApp.ViewModel;
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
            MainStartup();

            base.OnStartup(e);
        }

        private void Register()
        {
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<HomeViewModel>();
            Container.RegisterSingleton<LoginViewModel>();
            Container.RegisterSingleton<RegistrationViewModel>();
        }
        private void MainStartup()
        {
            var mainView = new MainView();
            mainView.DataContext = Container?.GetInstance<MainViewModel>();
            mainView.ShowDialog();
        }
    }
}
