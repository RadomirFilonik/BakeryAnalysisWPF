using BakeryAnalysis.Helpers;
using BakeryAnalysis.Models;
using BakeryAnalysis.Repositories;
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
        private static readonly ProductsRepository _productRepository = new ProductsRepository();
        private static readonly BuyersRepository _buyersRepository = new BuyersRepository();
        private static ObservableCollection<Buyer> buyers = new ObservableCollection<Buyer>();
        private static readonly Geters _geters = new Geters();

        public MainWindow()
        {
            InitializeComponent();

            var productsFromFile = _geters.GetProductsFromFile("FilesForAnalise/Products.csv");
            _productRepository.AddProducts(productsFromFile);
            var buyersFromFile = _geters.GetBuyersFromFileAndMapingItToBuyers("FilesForAnalise/Karol.csv", productsFromFile);
            _buyersRepository.AddBuyers(buyersFromFile);
            
            //var buyer = _buyersRepository.GetBuyers().FirstOrDefault();
            buyers = _buyersRepository.GetBuyers();

            buyersListName.ItemsSource = buyers.Select(x=> x.Name).ToList();
            buyersListPurched.ItemsSource = buyers.Select(x => x.Purchased.Sum()).ToList();
            buyersListReturned.ItemsSource = buyers.Select(x => x.Returned.Sum()).ToList();

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
