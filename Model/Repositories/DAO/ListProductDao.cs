using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAccountingSystem;

namespace Model.Repositories.DAO
{
    internal class ListProductDao : IProductDao
    {
        private List<Product> productList;
        private static ListProductDao INSTANCE;

       static public ListProductDao getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new ListProductDao();
            return INSTANCE;
        }

        private ListProductDao()
        {
            productList = new List<Product>();
            //прописать здесь тестовые продукты
        }

        public void addProduct(Product product)
        {
            productList.Add(product);
        }

        public void deleteProduct(long id)
        {
            productList.Remove(GetProduct(id));
        }

        public List<Product> getAllProducts()
        {
            return new List<Product>(productList);
        }

        public Product GetProduct(long id)
        {
            return productList.Where(product => product.IdProduct == id).FirstOrDefault(null);
        }
    }
}
