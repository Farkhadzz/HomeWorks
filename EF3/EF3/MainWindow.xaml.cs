using Microsoft.EntityFrameworkCore;
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
using static EF3.MainWindow;

namespace EF3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyDbContext dbContext;
        public MainWindow()
        {
            InitializeComponent();
            dbContext = new MyDbContext();
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Code { get; set; }
            public decimal Price { get; set; }
        }

        public class MyDbContext : DbContext
        {
            public DbSet<Product> Products { get; set;}

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ProductDB;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            int code = int.Parse(CodeTextBox.Text);
            decimal price = decimal.Parse(PriceTextBox.Text);

            Product newProduct = new Product
            {
                Name = name,
                Code = code,
                Price = price
            };

            dbContext.Products.Add(newProduct);
            dbContext.SaveChanges();

            MessageBox.Show("Товар успешно добавлен в базу данных.");
        }
    }
}
