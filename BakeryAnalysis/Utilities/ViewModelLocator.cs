using BakeryAnalysis.Helpers;
using BakeryAnalysis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.Utilities
{
    public class ViewModelLocator
    {
        private static readonly Geters _geters = new Geters();
        public BuyersAnaliseViewModel BuyersAnaliseViewModel;
        public ProductsAnaliseViewModel ProductsAnaliseViewModel;

        public ViewModelLocator()
        {
            var productsFromFile = _geters.GetProductsFromFile("FilesForAnalise/Products.csv");
            var buyersFromFile = _geters.GetBuyersFromFileAndMapingItToBuyers("FilesForAnalise/Karol.csv", productsFromFile);

            BuyersAnaliseViewModel = new BuyersAnaliseViewModel(buyersFromFile);
            ProductsAnaliseViewModel = new ProductsAnaliseViewModel(buyersFromFile);

        }
        
    }
}
