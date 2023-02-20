using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Calculator_App_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int firstNumber;
        int secondNumber;
        char operation;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            MathBlock.Text += btn.Content.ToString();
            secondNumber = Int32.Parse(MathBlock.Text);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = Int32.Parse(MathBlock.Text);
            operation = '+';
        }

        private void Sub_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = Int32.Parse(MathBlock.Text);
            operation = '-';
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            secondNumber = Int32.Parse(MathBlock.Text);
            int result = 0;

            if (operation == '+')
            {
                result = firstNumber + secondNumber;
            }

            else if (operation == '-')
            {
                result = firstNumber - secondNumber;
            }
            else if (operation == '*')
            {
                result = firstNumber * secondNumber;
            }
            else if (operation == '/')
            {
                result = firstNumber / secondNumber;

                if (firstNumber == 0 && secondNumber == 0)
                {
                    result = 0;
                }
            }
            else if (operation == 'A')
            {
                result = 0;
            }
            MathBlock.Text = result.ToString();
            
        }
    }
}
