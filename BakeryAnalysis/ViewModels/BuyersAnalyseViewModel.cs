using BakeryAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.ViewModels
{
    public class BuyersAnalyseViewModel
    {
        public ObservableCollection<Buyer> ReturnBuyersAnalyseViewModel(List<Buyer> listOfBuyers)
        {
            ObservableCollection<Buyer> allBuyers = new ObservableCollection<Buyer>();

            foreach (var buyer in listOfBuyers)
            {
                allBuyers.Add(buyer);
            }

            return allBuyers;
        }
    }
}
