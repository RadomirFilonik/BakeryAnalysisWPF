using BakeryAnalysis.Models;
using BakeryAnalysis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.Utilities
{
    public static class ViewModelLocator
    {
        private static Geters _geters = new Geters();
        //public static MainWindowViewModel MainWindowViewModel = new MainWindowViewModel(_geters.GetBuyersFromFileAndMapingItToBuyers("", _geters.GetProductsFromFile("FilesForAnalise/Products.csv")));
        //public static MainWindowViewModel MainWindowViewModel = new MainWindowViewModel(_geters.GetBuyersFromFileAndMapingItToBuyers("FilesForAnalise/KarolZly.csv", _geters.GetProductsFromFile("")));
        public static MainWindowViewModel MainWindowViewModel = new MainWindowViewModel(_geters.GetBuyersFromFileAndMapingItToBuyers("FilesForAnalise/KarolZly.csv", _geters.GetProductsFromFile("FilesForAnalise/Products.csv")));
        //public static MainWindowViewModel MainWindowViewModel = new MainWindowViewModel(_geters.GetBuyersFromFileAndMapingItToBuyers("FilesForAnalise/Karol.csv", _geters.GetProductsFromFile("FilesForAnalise/Products.csv")));
        public static BuyerDetailViewModel BuyerDetailViewModel;
        public static ProductDetailAnaliseViewModel ProductDetailAnaliseViewModel;

        public static void SetBuyerToBuyerDetailViewModel(Buyer buyer)
        {
            BuyerDetailViewModel = new BuyerDetailViewModel(buyer);
        }

        public static void SetProductToProductDetailAnaliseViewModel(ProductsAnalise selectedProductsAnalise, List<Buyer> listOfBuyers)
        {
            ProductDetailAnaliseViewModel = new ProductDetailAnaliseViewModel(selectedProductsAnalise, listOfBuyers);
        }

    }
}
