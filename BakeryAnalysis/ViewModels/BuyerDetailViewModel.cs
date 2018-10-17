using BakeryAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.ViewModels
{
    public class BuyerDetailViewModel
    {
        public ObservableCollection<ProductsAnalyse> Products { get; set; }
        public string SelectedBuyerName { get; set; }

        public BuyerDetailViewModel(Buyer selectedBuyer)
        {
            Products = new ObservableCollection<ProductsAnalyse>();
            SelectedBuyerName = selectedBuyer.Name;
            var countOfProducts = selectedBuyer.Product.Count();

            for (int i = 0; i < countOfProducts; i++)
            {
                if(selectedBuyer.Purchased[i] == 0 && selectedBuyer.Profits[i] == 0)
                {
                    continue;
                }
                else
                {
                    var newProduct = new ProductsAnalyse()
                    {
                        NameOfProduct = selectedBuyer.Product[i],
                        SumOfPurchased = selectedBuyer.Purchased[i],
                        SumOfReturned = selectedBuyer.Returned[i],
                        Sales = selectedBuyer.Purchased[i] - selectedBuyer.Returned[i],
                        SumOfProfits = selectedBuyer.Profits[i],
                    };
                    Products.Add(newProduct);
                }
                
            }
        }
    }
}
