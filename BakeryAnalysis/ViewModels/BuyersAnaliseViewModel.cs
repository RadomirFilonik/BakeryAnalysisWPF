using BakeryAnalysis.Helpers;
using BakeryAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.ViewModels
{
    public class BuyersAnaliseViewModel
    {
        private static readonly Geters _geters = new Geters();
        public ObservableCollection<Buyer> AllBuyers = new ObservableCollection<Buyer>();

        public BuyersAnaliseViewModel()
        {
            var productsFromFile = _geters.GetProductsFromFile("FilesForAnalise/Products.csv");
            var buyersFromFile = _geters.GetBuyersFromFileAndMapingItToBuyers("FilesForAnalise/Karol.csv", productsFromFile);

            foreach (var buyer in buyersFromFile)
            {
                AllBuyers.Add(buyer);
            }
        }
    }
}
