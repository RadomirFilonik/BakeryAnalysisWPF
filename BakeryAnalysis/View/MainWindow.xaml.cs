using BakeryAnalysis.Helpers;
using BakeryAnalysis.Models;
using BakeryAnalysis.Utilities;
using BakeryAnalysis.View;
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
        public MainWindow()
        {
            InitializeComponent();
            
            BuyersList.ItemsSource = ViewModelLocator.MainWindowViewModel.AllBuyers;
            ProducktsList.ItemsSource = ViewModelLocator.MainWindowViewModel.AllProductAnalise;

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBuyer = BuyersList.SelectedItem as Buyer;

            if (selectedBuyer != null)
            {
                ViewModelLocator.MainWindowViewModel.AllBuyers.Remove(selectedBuyer);
            }
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBuyer = BuyersList.SelectedItem as Buyer;

            if (selectedBuyer != null)
            {
                ViewModelLocator.SetBuyerToBuyerDetailViewModel(selectedBuyer);
                var _buyerDetailView = new BuyerDetailView();
                _buyerDetailView.ShowDialog();
            }
        }

        private void BuyerUserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectButton_Click(sender, e);
        }
    }
}
