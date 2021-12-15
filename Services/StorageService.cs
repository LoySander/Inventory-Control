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

        public List<StorageProduct> getProducts(ProductType type)
        {
            List<StorageProduct> products = productDao.getAllProducts();
            return products.Where(product => product.type == type).ToList();
        }

        public List<StorageProduct> getSortedProducts(ProductType type)
        {
            List<StorageProduct> products = getProducts(type);
            products.Sort(new ProductStockCopmarator());
            return products;
        }

        public StorageProduct GetProduct(long id)
        {
            return productDao.GetProduct(id);
        }

        public void addProduct(StorageProduct products)
        {
            List<StorageProduct> storageProducts = productDao.getAllProducts();
            string[] str = products.NameProduct.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (StorageProduct x in storageProducts)
            {
                foreach (string s in str)
                {
                    if (s == x.NameProduct)
                    {
                        x.Stock++;
                    }
                }

            }
            productDao.RenewAllProduct(storageProducts);
        }

        public void deleteProduct(long id)
        {
            productDao.deleteProduct(id);
        }
    }

    public class ProductStockCopmarator : IComparer<StorageProduct>
    {
        public int Compare(StorageProduct x, StorageProduct y)
        {
            return x.Stock - y.Stock;
        }
    }
}
