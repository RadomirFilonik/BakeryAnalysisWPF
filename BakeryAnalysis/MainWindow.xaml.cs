using BakeryAnalysis.Helpers;
using BakeryAnalysis.Models;
using BakeryAnalysis.Repositories;
using BakeryAnalysis.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace BakeryAnalysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModelLocator viewModelLocator = new ViewModelLocator();
        public MainWindow()
        {
            InitializeComponent();

            BuyersList.ItemsSource = viewModelLocator.BuyersAnaliseViewModel.AllBuyers;
            ProducktsList.ItemsSource = viewModelLocator.ProductsAnaliseViewModel.AllProductAnalise;


            //var buyer = _buyersRepository.GetBuyers().FirstOrDefault();
            //buyers = new ObservableCollection<Buyer>(buyersFromFile);
            //buyers.Remove(buyers.FirstOrDefault());

            //buyers = new ObservableCollection<Buyer>(buyersFromFile.Where(x => x.SumOfProfits != 0).ToList());
            //DataContext = buyers;

            //buyersListPurched.ItemsSource = buyers.Select(x => x.Purchased.Sum()).ToList();
            //buyersListReturned.ItemsSource = buyers.Select(x => x.Returned.Sum()).ToList();

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBuyer = BuyersList.SelectedItem as Buyer;

            if (selectedBuyer != null)
            {
                viewModelLocator.BuyersAnaliseViewModel.AllBuyers.Remove(selectedBuyer);
            }
        }
    }
}
