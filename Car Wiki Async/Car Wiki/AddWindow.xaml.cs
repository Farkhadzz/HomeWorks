using Car_Wiki.Model.Classes;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Car_Wiki
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public CarContext carContext;
        public AddWindow()
        {
            InitializeComponent();
            carContext = new CarContext();
        }

        private async void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string model = txtModel.Text;
            string brand = txtBrand.Text;
            int year = int.Parse(txtYear.Text);
            double motor = double.Parse(txtMotor.Text);
            int hp = int.Parse(txtHp.Text);
            string info = txtInfo.Text;
            if (ValidateWebsiteLink(info))
            {
                Car car = new Car
                {
                    Model = model,
                    Brand = brand,
                    Year = year,
                    Motor = motor,
                    Hp = hp,
                    Info = info
                };

                carContext.Cars.Add(car);
                carContext.SaveChangesAsync();
            }
            else MessageBox.Show("Info Only From Sites!");
        }
        private bool ValidateWebsiteLink(string link)
        {
            string myRegex = @"^(https?://)?([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$";

            Regex regex = new Regex(myRegex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(link);
        }
    }
}
