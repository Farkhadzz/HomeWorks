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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WhiteBoard.View
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            InitializeComponent();

            DoubleAnimation btnAnimation = new();
            btnAnimation.From = 0;
            btnAnimation.To = 320;
            btnAnimation.Duration = TimeSpan.FromSeconds(3);
            LogButton.BeginAnimation(Button.WidthProperty, btnAnimation);
        }
    }
}
