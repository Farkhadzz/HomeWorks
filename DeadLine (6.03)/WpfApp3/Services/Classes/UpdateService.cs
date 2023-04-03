using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp3.ViewModel;

namespace WpfApp3.Services.Classes
{
    public class UpdateService : ICommand
    {
        private MainViewModel viewModel;

        public UpdateService(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        bool ICommand.CanExecute(object? parameter)
        {
            return true;
        }

        void ICommand.Execute(object parameter)
        {
            Console.WriteLine("tmp");
            if (parameter.ToString() == "FirstView")
            {
                viewModel.CurrentViewModel = new FirstViewModel();
            }
            else if (parameter.ToString() == "SecondView")
            {
                viewModel.CurrentViewModel = new SecondViewModel();
            }
            else if (parameter.ToString() == "ThirdView")
            {
                viewModel.CurrentViewModel = new ThirdViewModel();
            }
        }
    }
}
