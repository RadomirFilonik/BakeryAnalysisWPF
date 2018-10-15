using BakeryAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.ViewModels
{
    public class ProductDetailAnaliseViewModel
    {
        public ObservableCollection<ProductDetailAnalise> ProductDetailAnalise { get; set; }
        public string SelectedProductName { get; set; }

        public ProductDetailAnaliseViewModel(Product selectedProduct)
        {
            ProductDetailAnalise = new ObservableCollection<ProductDetailAnalise>();
            SelectedProductName = selectedProduct.NameOfProduct;


        }
    }
}
