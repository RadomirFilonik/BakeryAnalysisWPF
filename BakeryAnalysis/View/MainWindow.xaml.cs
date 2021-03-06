﻿using BakeryAnalysis.Models;
using BakeryAnalysis.Utilities;
using BakeryAnalysis.View;
using BakeryAnalysis.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

            DataContext = ViewModelLocator.MainWindowViewModel;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBuyer = BuyersList.SelectedItem as Buyer;

            if (selectedBuyer != null)
            {
                ViewModelLocator.MainWindowViewModel.AllBuyers.Remove(selectedBuyer);

                var newListOfBuyers = ViewModelLocator.MainWindowViewModel.AllBuyers.ToList();
                
                ViewModelLocator.MainWindowViewModel.RecreateAllProductAnalyse(newListOfBuyers);
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

        private void ProductUserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectProductButton_Click(sender, e);
        }

        private void selectProductButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProducktsList.SelectedItem as ProductsAnalyse;

            if (selectedProduct != null)
            {
                var listOfBuyers = ViewModelLocator.MainWindowViewModel.AllBuyers.ToList();
                ViewModelLocator.SetProductToProductDetailAnalyseViewModel(selectedProduct, listOfBuyers);
                var _productDetailAnalyseView = new ProductDetailAnalyseView();
                _productDetailAnalyseView.ShowDialog();
            }
        }
    }
}
