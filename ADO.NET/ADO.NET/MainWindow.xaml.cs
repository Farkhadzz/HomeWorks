using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.WebSockets;
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

namespace ADO.NET
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

        private void All_Students_Click(object sender, RoutedEventArgs e)
        {
            using SqlConnection conn = new SqlConnection("Data Source=localhost;Database=AcademyDB V4;Trusted_Connection=True;");
            conn.Open();

            var query = new SqlCommand("SELECT * FROM [Students]", conn);
            SqlDataReader reader = query.ExecuteReader();
            var schema = reader.GetColumnSchema();

            foreach (var column in schema)
            {
                Results.Text += $"{column.ColumnName} \t";
            }
            while (reader.Read())
            {
                Results.Text += $"\n{reader.GetInt32(0)}\t{reader.GetString(1)}\t{reader.GetString(2)}\t{reader.GetInt32(3)}";
            }
            conn.Close();
        }

        private void Max_Click(object sender, RoutedEventArgs e)
        {
            using SqlConnection conn = new SqlConnection("Data Source=localhost;Database=AcademyDB V4;Trusted_Connection=True;");
            conn.Open();

            var query = new SqlCommand($"SELECT MAX(Rating) FROM [Students]", conn);
            var reader = query.ExecuteScalar();
            Results.Text = reader.ToString();
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            using SqlConnection conn = new SqlConnection("Data Source=localhost;Database=AcademyDB V4;Trusted_Connection=True;");
            conn.Open();

            var query = new SqlCommand($"SELECT MIN(Rating) FROM [Students]", conn);
            var reader = query.ExecuteScalar();
            Results.Text = reader.ToString();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            using SqlConnection conn = new SqlConnection("Data Source=localhost;Database=AcademyDB V4;Trusted_Connection=True;");
            conn.Open();

            var query = new SqlCommand(Query.Text, conn);

            SqlDataReader reader = query.ExecuteReader();
            var schema = reader.GetColumnSchema();

            foreach (var column in schema)
            {
                Results.Text += $"{column.ColumnName} \t";
            }

            while (reader.Read())
            {
                Results.Text += $"\n{reader.GetInt32(0)}\t{reader.GetString(1)}\t{reader.GetString(2)}\t{reader.GetInt32(3)}";
            }
            conn.Close();
        }

    }
}
