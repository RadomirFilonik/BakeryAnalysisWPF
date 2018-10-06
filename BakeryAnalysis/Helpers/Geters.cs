using BakeryAnalysis.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.Helpers
{
    public class Geters
    {
        public List<Buyer> GetBuyersFromFileAndMapingItToBuyers(string adress, List<Product> listOfProducts)
        {
            var listOfBuyers = new List<Buyer>();

            using (var reader = new StreamReader(adress))
            {
                var file = reader.ReadToEnd();
                var lines = file.Split(new char[] { '\n' });
                var count = lines.Count();

                var firstLineSplited = lines[1].Split(';');

                var HowManyBuyers = firstLineSplited.Count(x => x != "") - 1;
                var NamesOfBuyers = firstLineSplited.Where(x => x != "").ToArray();

                for (int i = 0; i < HowManyBuyers; i++)
                {
                    var buyer = new Buyer();
                    buyer.Name = NamesOfBuyers[i];
                    listOfBuyers.Add(buyer);
                }

                var linesWithData = lines.Skip(3);

                foreach (var line in linesWithData)
                {
                    var columnsInLine = line.Split(';');
                    for (int i = 0; i < HowManyBuyers; i++)
                    {
                        var buyer = listOfBuyers[i];
                        var productName = columnsInLine[0];
                        double purchased;
                        double returned;
                        double prise;
                        string currentString;

                        buyer.Product.Add(productName);
                        currentString = columnsInLine[i * 4 + 1];
                        if (currentString == "")
                        {
                            purchased = 0;
                        }
                        else
                        {
                            purchased = double.Parse(currentString);
                        }
                        buyer.Purchased.Add(purchased);
                        currentString = columnsInLine[i * 4 + 2];
                        if (currentString == "")
                        {
                            returned = 0;
                        }
                        else
                        {
                            returned = double.Parse(currentString);
                        }
                        buyer.Returned.Add(returned);
                        currentString = columnsInLine[i * 4 + 3];
                        if (currentString == "")
                        {
                            prise = 0;
                        }
                        else
                        {
                            prise = double.Parse(currentString);
                        }
                        buyer.Prise.Add(prise);
                    }
                }

            }

            foreach (var buyer in listOfBuyers)
            {
                var procuctCount = buyer.Product.Count();
                double sumOfProfits = 0;


                for (int i = 0; i < procuctCount; i++)
                {

                    var indexOfProduct = listOfProducts.FindIndex(x => x.NameOfProduct == buyer.Product[i]);
                    var productMaterialCost = listOfProducts[indexOfProduct].MaterialCost;
                    var profit = (buyer.Purchased[i] - buyer.Returned[i]) * buyer.Prise[i] - buyer.Purchased[i] * productMaterialCost;

                    sumOfProfits += profit;
                    buyer.Profits.Add(profit);
                }

                buyer.SumOfProfits = sumOfProfits;
            }

            return listOfBuyers;
        }

        public List<Product> GetProductsFromFile(string adress)
        {
            var listOfProducts = new List<Product>();
            using (var reader = new StreamReader(adress))
            {
                var file = reader.ReadToEnd();
                var lines = file.Split(new char[] { '\n' }).Skip(1);
                
                foreach (var line in lines)
                {
                    var properties = line.Split(';');
                    var newProduct = new Product()
                    {
                        NameOfProduct = properties[0],
                        Media = properties[2],
                        Modifier = properties[3]
                    };

                    if (properties[1] == "")
                    {
                        newProduct.MaterialCost = 0;
                    }
                    else
                    {
                        newProduct.MaterialCost = double.Parse(properties[1]);
                    }

                    listOfProducts.Add(newProduct);
                }
                
            }

            return listOfProducts;
        }
    }
}
