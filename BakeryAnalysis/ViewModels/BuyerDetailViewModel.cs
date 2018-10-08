using BakeryAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.ViewModels
{
    public class BuyerDetailViewModel
    {
        public Buyer Buyer = new Buyer();

        public BuyerDetailViewModel(Buyer selectedBuyer)
        {
            Buyer = selectedBuyer;
        }
    }
}
