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
    public class ProductDetailAnaliseViewModel
    {
        public ObservableCollection<ProductDetailAnalise> ProductDetailAnalise { get; set; }
        public string SelectedProductName { get; set; }

        public ProductDetailAnaliseViewModel(ProductsAnalise selectedProductsAnalise, List<Buyer> listOfBuyers)
        {
            ProductDetailAnalise = new ObservableCollection<ProductDetailAnalise>();
            SelectedProductName = selectedProductsAnalise.NameOfProduct;
            

            var numberOfDiffrentPrices = 0;
            var indexOfProduct = SetIndexOfProductFromBuyersList(listOfBuyers.FirstOrDefault());
            var listOfPrices = CreateListOfPrices(listOfBuyers, indexOfProduct);

            var listOfDiffrentPrices = listOfPrices.Distinct().OrderByDescending(x => x).ToList();
            numberOfDiffrentPrices = listOfDiffrentPrices.Count();

            ProductDetailAnalise = CreateListOfProductDetailAnalise(numberOfDiffrentPrices, indexOfProduct, listOfDiffrentPrices, listOfBuyers);
        }
 
        private List<double> CreateListOfPrices(List<Buyer> listOfBuyers, int indexOfProductInListOfBuyers)
        {
            var newListOfPrices = new List<double>();
            for (int i = 0; i < listOfBuyers.Count(); i++)
            {
                var price = listOfBuyers[i].Price[indexOfProductInListOfBuyers];
                newListOfPrices.Add(price);
            }
            return newListOfPrices;
        }

        private int SetIndexOfProductFromBuyersList(Buyer buyer)
        {
            int result = 0;
            for (int i = 0; i < buyer.Product.Count(); i++)
            {
                if (buyer.Product[i] == SelectedProductName)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        private ObservableCollection<ProductDetailAnalise> CreateListOfProductDetailAnalise(int numberOfDiffrentPrices, int indexOfProduct, List<double> listOfDiffrentPrices, List<Buyer> listOfBuyers)
        {
            ObservableCollection<ProductDetailAnalise> result = new ObservableCollection<ProductDetailAnalise>();

            for (int i = 0; i < numberOfDiffrentPrices; i++)
            {
                double price = listOfDiffrentPrices[i];
                if (price != 0)
                {
                    double sumOfPurchased = 0;
                    double sumOfReturned = 0;
                    double sales = 0;
                    double sumOfProfits = 0;

                    for (int j = 0; j < listOfBuyers.Count(); j++)
                    {
                        if (listOfBuyers[j].Price[indexOfProduct] == price)
                        {
                            sumOfPurchased += listOfBuyers[j].Purchased[indexOfProduct];
                            sumOfReturned += listOfBuyers[j].Returned[indexOfProduct];
                            sales = sumOfPurchased - sumOfReturned;
                            sumOfProfits += listOfBuyers[j].Profits[indexOfProduct];
                        }

                    }

                    var newProductDetailAnalise = new ProductDetailAnalise
                    {
                        SumOfProfits = sumOfProfits,
                        SumOfPurchased = sumOfPurchased,
                        SumOfReturned = sumOfReturned,
                        Sales = sales,
                        Price = price
                    };

                    result.Add(newProductDetailAnalise);
                }
                
            }
            return result;
        }

    }
}
