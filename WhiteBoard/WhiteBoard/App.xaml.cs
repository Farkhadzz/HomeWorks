using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WhiteBoard.Services.Classes;
using WhiteBoard.Services.Interfaces;
using WhiteBoard.View;
using WhiteBoard.ViewModel;

namespace WhiteBoard
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

            var start = App.Container.GetInstance<LoginViewModel>();

            MainStartup();

            base.OnStartup(e);
        }

        private void Register()
        {
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<Services.Interfaces.INavigationService, NavigationService>();
            Container.RegisterSingleton<ISendService, SendService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<LoginViewModel>();
            Container.RegisterSingleton<RegistrationViewModel>();
            Container.RegisterSingleton<BoardViewModel>();
            Container.RegisterSingleton<SendViewModel>();
        }
        private void MainStartup()
        {
            var mainView = new MainView();
            mainView.DataContext = Container?.GetInstance<MainViewModel>();
            mainView.ShowDialog();
        }
    }

}