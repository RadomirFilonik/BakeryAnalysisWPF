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
        public ObservableCollection<ProductAnalise> ReturnProductsAnaliseViewModel(List<Buyer> listOfBuyers)
        {
            ObservableCollection<ProductAnalise> allProductAnalise = new ObservableCollection<ProductAnalise>();
            if (listOfBuyers.Count() != 0)
            {
                var ListOfProducts = listOfBuyers.FirstOrDefault().Product;
                var countOfProducts = ListOfProducts.Count();
                var countOfBuyers = listOfBuyers.Count();

                for (int i = 0; i < countOfProducts; i++)
                {
                    double sumOfPrusched = 0;
                    double sumOfPReturned = 0;
                    double sumOfProfits = 0;
                    var nameOfProduct = ListOfProducts[i];

                    for (int j = 0; j < countOfBuyers; j++)
                    {
                        sumOfPrusched += listOfBuyers[j].Purchased[i];
                        sumOfPReturned += listOfBuyers[j].Returned[i];
                        sumOfProfits += listOfBuyers[j].Profits[i];
                    }
                    double sales = sumOfPrusched - sumOfPReturned;

                    var productAnalise = new ProductAnalise()
                    {
                        NameOfProduct = nameOfProduct,
                        SumOfPurchased = sumOfPrusched,
                        SumOfReturned = sumOfPReturned,
                        Sales = sales,
                        SumOfProfits = sumOfProfits
                    };

                    allProductAnalise.Add(productAnalise);
                }
            }
            return allProductAnalise;
        }
    }
}
