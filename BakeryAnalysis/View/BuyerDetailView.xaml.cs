using BakeryAnalysis.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BakeryAnalysis.View
{
    /// <summary>
    /// Interaction logic for BuyerDetailView.xaml
    /// </summary>
    public partial class BuyerDetailView : Window
    {
        public BuyerDetailView()
        {
            InitializeComponent();
            DataContext = ViewModelLocator.BuyerDetailViewModel.Buyer;
        }
    }
}
