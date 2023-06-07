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
using Countries_V1.Classes;

namespace Countries_V1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CountryContext dbContext;
        public MainWindow()
        {
            InitializeComponent();
            dbContext = new CountryContext();
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            int yearCreated = int.Parse(txtYearCreated.Text);
            string governmentType = txtGovernmentType.Text;
            string mapImageUrl = txtMapImageUrl.Text;
            long population = long.Parse(txtPopulation.Text);
            double area = double.Parse(txtArea.Text);
            decimal gdp = decimal.Parse(txtGDP.Text);

            Country country = new Country
            {
                Name = name,
                YearCreated = yearCreated,
                GovernmentType = governmentType,
                MapImageUrl = mapImageUrl,
                Population = population,
                Area = area,
                GDP = gdp
            };

            dbContext.Countries.Add(country);
            dbContext.SaveChanges();
        }

        private void ShowAllCountires_Click(object sender, RoutedEventArgs e) 
        {
            List<Country> countries = dbContext.Countries.ToList();
            countryListView.ItemsSource = countries;
        }

        private void RemoveCountry_Click(object sender, RoutedEventArgs e)
        {
            if (countryListView.SelectedItem is Country selectedCountry)
            {
                dbContext.Countries.Remove(selectedCountry);
                dbContext.SaveChanges();

                List<Country> countries = dbContext.Countries.ToList();
                countryListView.ItemsSource = countries;
            }
        }
    }
}
