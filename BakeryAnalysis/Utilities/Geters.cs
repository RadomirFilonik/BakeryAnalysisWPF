using BakeryAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.Utilities
{
    public class Geters
    {
        public List<Buyer> GetBuyersFromFileAndMapingItToBuyers(string adress, List<Product> listOfProducts)
        {
            var listOfBuyers = new List<Buyer>();

            if(adress != "")
            {
                using (var reader = new StreamReader(adress, Encoding.UTF8))
                {
                    var file = reader.ReadToEnd();
                    var lines = file.Split(new char[] { '\n' }).ToList();
                    lines = RemoveEmptyLinesOnEndOfFile(lines);

                    var firstLineSplited = lines[1].Split(';');

                    var HowManyBuyers = firstLineSplited.Count(x => x != "") - 1;
                    var NamesOfBuyers = firstLineSplited.Where(x => x != "").ToArray();

                    for (int i = 0; i < HowManyBuyers; i++)
                    {
                        var buyer = new Buyer();
                        buyer.Name = NamesOfBuyers[i];
                        listOfBuyers.Add(buyer);
                    }

                    var linesWithData = lines.Skip(3).ToList();


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
                            currentString = RemoveQuotationMarks(currentString);
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
                            currentString = RemoveQuotationMarks(currentString);
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
                            currentString = RemoveQuotationMarks(currentString);
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

                List<Product> listOfActiveProducts = new List<Product>();
                int numbersOfActiveProducts = listOfBuyers.FirstOrDefault().Product.Count();
                for (int i = 0; i < numbersOfActiveProducts; i++)
                {
                    var listOfProductCount = listOfProducts.Count();

                    for (int j = 0; j < listOfProductCount; j++)
                    {
                        if (listOfProducts[j].NameOfProduct == listOfBuyers.FirstOrDefault().Product[i])
                        {
                            listOfActiveProducts.Add(listOfProducts[j]);
                            break;
                        }
                    }
                }


                foreach (var buyer in listOfBuyers)
                {
                    var productCount = buyer.Product.Count();
                    double sumOfProfits = 0;

                    for (int i = 0; i < productCount; i++)
                    {
                        double productMaterialCost;
                        
                        if (listOfProducts.Count() != 0)
                        {
                            productMaterialCost = listOfActiveProducts[i].MaterialCost;
                        }
                        else
                        {
                            productMaterialCost = 0;
                        }


                        var profit = (buyer.Purchased[i] - buyer.Returned[i]) * buyer.Prise[i] - buyer.Purchased[i] * productMaterialCost;

                        sumOfProfits += profit;
                        buyer.Profits.Add(profit);
                        
                    }
                    buyer.SumOfProfits = sumOfProfits;
                }


            }

            return listOfBuyers;
        }
        

        public List<Product> GetProductsFromFile(string adress)
        {
            var listOfProducts = new List<Product>();
            if (adress != "")
            {
                using (var reader = new StreamReader(adress))
                {
                    var file = reader.ReadToEnd();
                    var lines = file.Split(new char[] { '\n' }).Skip(1).ToList();
                    lines = RemoveEmptyLinesOnEndOfFile(lines);


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
            }

            return listOfProducts;
        }

        private List<string> RemoveEmptyLinesOnEndOfFile(List<string> linesWithData)
        {
            linesWithData.Reverse();
            var numberOfLines = linesWithData.Count();
            int numberOfEmptyLines = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                var line = linesWithData[i].Split(';');
                if(line[0] == string.Empty || line[0] == "\r" || line[0] == "\n")
                {
                    numberOfEmptyLines++;
                }
                else
                {
                    break;
                }
            }

            linesWithData = linesWithData.Skip(numberOfEmptyLines).ToList();
            linesWithData.Reverse();
            return linesWithData;
        }

        private string RemoveQuotationMarks(string currentString)
        {
            return currentString.Replace("\"", string.Empty);

        }
    }
}
