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
    }
}
