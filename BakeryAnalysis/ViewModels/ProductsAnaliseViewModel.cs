using BakeryAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.ViewModels
{
    public class ProductsAnaliseViewModel
    {
        public ObservableCollection<ProductAnalise> AllProductAnalise = new ObservableCollection<ProductAnalise>();

        public ProductsAnaliseViewModel(List<Buyer> listOfBuyers)
        {
            var countOfProduct = listOfBuyers.FirstOrDefault().Product.Count();

            var sumOfPurchased = listOfBuyers.Select(x => x.Purchased.Sum()).ToArray();
            var sumOfReturned = listOfBuyers.Select(x => x.Returned.Sum()).ToArray();
            var SumOfProfits = listOfBuyers.Select(x => x.Profits.Sum()).ToArray();

            for (int i = 0; i < countOfProduct; i++)
            {
                var productAnalise = new ProductAnalise()
                {
                    NameOfProduct = listOfBuyers.FirstOrDefault().Product[i],
                    SumOfPurchased = sumOfPurchased[i],
                    SumOfReturned = sumOfReturned[i],
                    SumOfProfits = SumOfProfits[i],
                    Sales = sumOfPurchased[i] - sumOfReturned[i]
                };

                AllProductAnalise.Add(productAnalise);
            }
        }
    }
}
