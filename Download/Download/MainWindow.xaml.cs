using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
using Download.Models;

namespace Download
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Car> carList = new List<Car>
        {
            new Car("BMW","M5 E60", 2005, 507),
            new Car("Merdeces-Benz", "C280", 1999, 196)
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            Thread threadDownload = new(DownloadData);
            threadDownload.Start();
        }

        private void DownloadData()
        {
            foreach (Car car in carList)
            {
                Dispatcher.Invoke(() => carListBox.Items.Add(car));
            }
        }

        private void CarListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Car selectedCar = carListBox.SelectedItem as Car;

            if (selectedCar != null)
            {
                infoListBox.Items.Clear();

                infoListBox.Items.Add(selectedCar);
            }
        }
    }
}
