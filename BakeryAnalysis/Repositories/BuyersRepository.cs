using BakeryAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.Repositories
{
    public class BuyersRepository
    {
        private ObservableCollection<Buyer> _allBuyers = new ObservableCollection<Buyer>();

        public ObservableCollection<Buyer> GetBuyers()
        {
            return _allBuyers;
        }

        public void AddBuyers(List<Buyer> listOfBuyers)
        {
            foreach (var buyer in listOfBuyers)
            {
                _allBuyers.Add(buyer);
            }
        }

        public Buyer GetBuyerByIndex(int i)
        {
            return _allBuyers[i];
        }
    }
}
