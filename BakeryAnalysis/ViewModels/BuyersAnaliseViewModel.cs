using BakeryAnalysis.Helpers;
using BakeryAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.ViewModels
{
    public class BuyersAnaliseViewModel
    {
        
        public ObservableCollection<Buyer> AllBuyers = new ObservableCollection<Buyer>();

        public BuyersAnaliseViewModel(List<Buyer> listOfBuyers)
        {
            foreach (var buyer in listOfBuyers)
            {
                AllBuyers.Add(buyer);
            }
        }
    }
}
