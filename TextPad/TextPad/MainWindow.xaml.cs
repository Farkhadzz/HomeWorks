using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TextPad.Classes;

namespace TextPad
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Document> Documents { get; set; } = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Documents.Add(new Document("", ""));
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Documents.Remove(MainListView.SelectedItem as Document);
        }
    }
}
