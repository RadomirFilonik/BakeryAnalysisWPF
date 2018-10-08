﻿using BakeryAnalysis.Helpers;
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
        public MainWindow()
        {
            InitializeComponent();

            BuyersList.ItemsSource = ViewModelLocator.BuyersAnaliseViewModel.AllBuyers;
            ProducktsList.ItemsSource = ViewModelLocator.ProductsAnaliseViewModel.AllProductAnalise;


            //var buyer = _buyersRepository.GetBuyers().FirstOrDefault();
            //buyers = new ObservableCollection<Buyer>(buyersFromFile);
            //buyers.Remove(buyers.FirstOrDefault());

            //buyers = new ObservableCollection<Buyer>(buyersFromFile.Where(x => x.SumOfProfits != 0).ToList());
            //DataContext = buyers;

            //buyersListPurched.ItemsSource = buyers.Select(x => x.Purchased.Sum()).ToList();
            //buyersListReturned.ItemsSource = buyers.Select(x => x.Returned.Sum()).ToList();

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBuyer = BuyersList.SelectedItem as Buyer;

            if (selectedBuyer != null)
            {
                ViewModelLocator.BuyersAnaliseViewModel.AllBuyers.Remove(selectedBuyer);
            }
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
