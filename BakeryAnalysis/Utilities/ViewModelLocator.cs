using BakeryAnalysis.Helpers;
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
        static Geters _geters = new Geters();
        public static BuyersAnaliseViewModel BuyersAnaliseViewModel = new BuyersAnaliseViewModel(_geters.GetBuyersFromFileAndMapingItToBuyers("FilesForAnalise/Karol.csv", _geters.GetProductsFromFile("FilesForAnalise/Products.csv")));
        public static ProductsAnaliseViewModel ProductsAnaliseViewModel = new ProductsAnaliseViewModel(_geters.GetBuyersFromFileAndMapingItToBuyers("FilesForAnalise/Karol.csv", _geters.GetProductsFromFile("FilesForAnalise/Products.csv")));
        public static BuyerDetailViewModel BuyerDetailViewModel;

        public static void SetBuyerToBuyerDetailViewModel(Buyer buyer)
        {
            BuyerDetailViewModel = new BuyerDetailViewModel(buyer);
        }
        
    }
}
