using StoreApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StoreApp.ViewModel;

namespace StoreApp.View
{
    public partial class RegistrationView : UserControl
    {
        public RegistrationView()
        {
            InitializeComponent();
            DataContext = new RegistrationViewModel();
        }
    }
}
