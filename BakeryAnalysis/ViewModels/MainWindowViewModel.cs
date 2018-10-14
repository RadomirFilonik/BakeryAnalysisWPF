using BakeryAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.ViewModels
{
    public class MainWindowViewModel
    {
        private readonly ProductsAnaliseViewModel _productsAnaliseViewModel = new ProductsAnaliseViewModel();
        private readonly BuyersAnaliseViewModel _buyersAnaliseViewModel = new BuyersAnaliseViewModel();

        public ObservableCollection<ProductAnalise> AllProductAnalise { get; set; }
        public ObservableCollection<Buyer> AllBuyers { get; set; }

        public MainWindowViewModel(List<Buyer> listOfBuyers)
        {
            AllProductAnalise = new ObservableCollection<ProductAnalise>();
            AllBuyers = new ObservableCollection<Buyer>();
            AllBuyers = _buyersAnaliseViewModel.ReturnBuyersAnaliseViewModel(listOfBuyers);
            AllProductAnalise = _productsAnaliseViewModel.ReturnProductsAnaliseViewModel(listOfBuyers);
        }
    }
}
