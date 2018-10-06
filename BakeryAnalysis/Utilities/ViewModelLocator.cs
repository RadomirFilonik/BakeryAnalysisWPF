using BakeryAnalysis.Helpers;
using BakeryAnalysis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.Utilities
{
    public class ViewModelLocator
    {
        public BuyersAnaliseViewModel BuyersAnaliseViewModel;

        public ViewModelLocator()
        {
            BuyersAnaliseViewModel = new BuyersAnaliseViewModel();
        }
        
    }
}
