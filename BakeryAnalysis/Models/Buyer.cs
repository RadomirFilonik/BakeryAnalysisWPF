using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.Models
{
    public class Buyer
    {
        public string Name { get; set; }
        public List<string> Product = new List<string>();
        public List<double> Purchased = new List<double>();
        public List<double> Returned = new List<double>();
        public List<double> Prise = new List<double>();
        public List<double> Profits = new List<double>();
        public double SumOfProfits { get; set; }
        

        public void DisplayBuyer()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Product          Purchased          Returned         Prise");

            for (int i = 0; i < Product.Count(); i++)
            {
                Console.WriteLine($"{Product[i]}      {Purchased[i]}            {Returned[i]}         {Prise[i]} ");
            }
        }

        public void DisplayProduktsAndProfits()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Product | Profits");
            for (int i = 0; i < Product.Count(); i++)
            {
                Console.WriteLine($"{Product[i]}  |  {Profits[i]} ");
            }

            Console.WriteLine("sum of Profits = " + SumOfProfits);
        } 
    }
}
