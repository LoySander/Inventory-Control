using Model.Repositories.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAccountingSystem;

namespace Services
{
    public class StorageService
    {
        private IProductDao productDao;
        private static StorageService INSTANCE;

        public static StorageService getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new StorageService();
            return INSTANCE;
        }

        private StorageService()
        {
            productDao = ListProductDao.getInstance();
        }

        public List<Product> getProducts(ProductType type)
        {
            List<Product> products = productDao.getAllProducts();
            return products.Where(product => product.type == type).ToList();
        }

        public List<Product> getSortedProducts(ProductType type)
        {
            List<Product> products = getProducts(type);
            products.Sort(new ProductStockCopmarator());
            return products;
        }

        public Product GetProduct(long id)
        {
            return productDao.GetProduct(id);
        }

        public void addProduct(Product product)
        {
            productDao.addProduct(product);
        }

        public void deleteProduct(long id)
        {
            productDao.deleteProduct(id);
        }
    }

    public class ProductStockCopmarator : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return x.Stock - y.Stock;
        }
    }
}
