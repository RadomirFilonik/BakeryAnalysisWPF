using BakeryAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAnalysis.Repositories
{
    public class ProductsRepository
    {
        private List<Product> _allProducts = new List<Product>();

        public IEnumerable<Product> GetBuyers()
        {
            return _allProducts;
        }

        public void AddProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                _allProducts.Add(product);
            }
        }
    }
}
