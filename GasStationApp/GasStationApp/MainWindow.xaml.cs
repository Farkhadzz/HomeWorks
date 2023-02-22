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
using System.Xml.XPath;

namespace GasStationApp
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

        double normalOil = 1;
        double superOil = 2;
        double premiumOil = 2.5;
        double hotDog = 1.5;
        double fries = 2.4;
        double burger = 2.7;
        double result;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PetrolBox.SelectedIndex == 0)
            {
                string litersConvert = LitersBox.Text;
                double liters = Convert.ToDouble(litersConvert);
                result = liters * normalOil;
                PriceBox.Text = result.ToString();
            }

            else if (PetrolBox.SelectedIndex == 1)
            {
                string litersConvert = LitersBox.Text;
                double liters = Convert.ToDouble(litersConvert);
                result = liters * superOil;
                PriceBox.Text = result.ToString();
            }

            else if (PetrolBox.SelectedIndex == 2)
            {
                string litersConvert = LitersBox.Text;
                double liters = Convert.ToDouble(litersConvert);
                result = liters * premiumOil;
                PriceBox.Text = result.ToString();
            }

            if (HotDogCheck.IsChecked == true && HotDogBox != null)
            {
                string converter = HotDogBox.Text;
                double quantity = Convert.ToDouble(converter);
                result += hotDog * quantity;
                PriceBox.Text = result.ToString();
            }

            if (FriesCheck.IsChecked == true && FriesBox != null)
            {
                string converter = FriesBox.Text;
                double quantity = Convert.ToDouble(converter);
                result += fries * quantity;
                PriceBox.Text = result.ToString();
            }

            else if (BurgerCheck.IsChecked == true && BurgerBox != null)
            {
                string converter = BurgerBox.Text;
                double quantity = Convert.ToDouble(converter);
                result += burger * quantity;
                PriceBox.Text = result.ToString();
            }

            if (HotDogBox == null)
            {
                HotDogBox.ToolTip = "Enter Correctly !";
                HotDogBox.Background = Brushes.DarkRed;
            }

            else if (FriesBox == null)
            {
                FriesBox.ToolTip = "Enter Correctly !";
                FriesBox.Background = Brushes.DarkRed;
            }

            else if (BurgerBox == null)
            {
                BurgerBox.ToolTip = "Enter Correctly !";
                BurgerBox.Background = Brushes.DarkRed;
            }
        }
    }
}
