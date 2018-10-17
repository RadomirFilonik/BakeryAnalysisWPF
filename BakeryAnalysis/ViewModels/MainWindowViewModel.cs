using BakeryAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.ViewModels
{
    public class MainWindowViewModel
    {
        private readonly ProductsAnalyseViewModel _productsAnalyseViewModel = new ProductsAnalyseViewModel();
        private readonly BuyersAnalyseViewModel _buyersAnalyseViewModel = new BuyersAnalyseViewModel();

        public ObservableCollection<ProductsAnalyse> AllProductAnalyse { get; set; }
        public ObservableCollection<Buyer> AllBuyers { get; set; }

        public MainWindowViewModel(List<Buyer> listOfBuyers)
        {
            AllProductAnalyse = new ObservableCollection<ProductsAnalyse>();
            AllBuyers = new ObservableCollection<Buyer>();
            AllBuyers = _buyersAnalyseViewModel.ReturnBuyersAnalyseViewModel(listOfBuyers);
            AllProductAnalyse = _productsAnalyseViewModel.ComputeProductsAnalyseViewModel(listOfBuyers);
        }

        public void RecreateAllProductAnalyse(List<Buyer> newListOfBuyers)
        {
            Debug.WriteLine(AllProductAnalyse.Count());
            var countOfAllProductAnalyse = AllProductAnalyse.Count();
            for (int i = 0; i < countOfAllProductAnalyse; i++)
            {
                AllProductAnalyse.Remove(AllProductAnalyse[0]);
            }

            Debug.WriteLine(AllProductAnalyse.Count);

            var newList = _productsAnalyseViewModel.ComputeProductsAnalyseViewModel(newListOfBuyers);

            foreach (var productsAnalyse in newList)
            {
                AllProductAnalyse.Add(productsAnalyse);
            }
        }
    }
}
