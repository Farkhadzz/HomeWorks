using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Text.Json;
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

namespace WPF_Practice_3
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

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text;
            string pass = textBoxPass.Password;
            string pass_2 = textBoxConPass.Password;
            string mail = textBoxMail.Text.ToLower();
            bool registrationCheck = false;

            User p1 = new(login , pass , mail);

            if (login.Length < 6)
            {
                textBoxLogin.ToolTip = "Enter Correctly !";
                textBoxLogin.Background = Brushes.DarkRed;
            }

            else if (pass.Length < 5)
            {
                textBoxPass.ToolTip = "Enter Correctly !";
                textBoxPass.Background = Brushes.DarkRed;
            }

            else if (pass != pass_2)
            {
                textBoxConPass.ToolTip = "Enter Correctly !";
                textBoxConPass.Background = Brushes.DarkRed;
            }

            else if (mail.Length < 5 || !mail.Contains("@") || !mail.Contains("."))
            {
                textBoxMail.ToolTip = "Enter Corrcetly !";
                textBoxMail.Background = Brushes.DarkRed;
            }

            else 
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                textBoxPass.ToolTip = "";
                textBoxPass.Background = Brushes.Transparent;
                textBoxConPass.ToolTip = "";
                textBoxConPass.Background = Brushes.Transparent;
                textBoxMail.ToolTip = "";
                textBoxMail.Background = Brushes.Transparent;
                registrationCheck = true;

                MessageBox.Show("LOGIN IS SUCCESFUL");
            }

            if (registrationCheck == true)
            {
                using FileStream fs = new("data.json", FileMode.OpenOrCreate);
                JsonSerializer.Serialize(fs, p1);

            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new();
            authWindow.Show();
            Hide();
        }
    }
}
