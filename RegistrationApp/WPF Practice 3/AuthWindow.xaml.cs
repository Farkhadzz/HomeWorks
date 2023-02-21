using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Practice_3
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string loginAuth = LoginNameBox.Text;
            string mailAuth = MailNameBox.Text.ToLower();
            string passwordAuth = PasswordBox.Password;
            bool registrationCheck = false;

            using FileStream fs = new("data.json", FileMode.Open);
            var user = JsonSerializer.Deserialize<User>(fs);


            if (loginAuth.Length < 6)
            {
                LoginNameBox.ToolTip = "Enter Correctly !";
                LoginNameBox.Background = Brushes.DarkRed;
            }

            else if (passwordAuth.Length < 5)
            {
                PasswordBox.ToolTip = "Enter Correctly !";
                PasswordBox.Background = Brushes.DarkRed;
            }

            else if (mailAuth.Length < 5 || !mailAuth.Contains("@") || !mailAuth.Contains("."))
            {
                MailNameBox.ToolTip = "Enter Corrcetly !";
                MailNameBox.Background = Brushes.DarkRed;
            }

            else
            {
                LoginNameBox.ToolTip = "";
                LoginNameBox.Background = Brushes.Transparent;
                PasswordBox.ToolTip = "";
                PasswordBox.Background = Brushes.Transparent;
                MailNameBox.ToolTip = "";
                MailNameBox.Background = Brushes.Transparent;
                registrationCheck = true;





                if (loginAuth == user.Login)
                {
                    MessageBox.Show("Login Success");
                }
                else if (mailAuth == user.Mail)
                {
                    MessageBox.Show("Mail Success");
                }
                else if (passwordAuth == user.Password)
                {
                    MessageBox.Show("Password Success");
                }
            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
