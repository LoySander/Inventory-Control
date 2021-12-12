using Model;
using Model.Repositories.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAccountingSystem;

namespace Services
{
    public class ClientProductService
    {
        private IProductDao productDao;
        private static ClientProductService INSTANCE;

        public static ClientProductService getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new ClientProductService();
            return INSTANCE;
        }

        private ClientProductService()
        {
            productDao = ListProductDao.getInstance();
        }

        public  List<Product> getProducts(ProductType type)
        {
            List<StorageProduct> products = productDao.getAllProducts();
            List<Product> clientProducts = new List<Product>();
            products = products.Where(product => product.type == type & product.Stock > 0).ToList();
            products.ForEach(product =>
            {
                Product clientProduct = new Product();
                clientProduct.IdProduct = product.IdProduct;
                clientProduct.NameProduct = product.NameProduct;
                clientProduct.WeightProduct = product.WeightProduct;
                clientProduct.CostProduct = product.CostProduct;
                clientProduct.CountryProduct = product.CountryProduct;
                clientProduct.DescriptionProduct = product.DescriptionProduct;
                clientProducts.Add(clientProduct);
            });
            return clientProducts;
        }

        public StorageProduct GetProduct(long id)
        {
            return productDao.GetProduct(id);
        }

        public void addProduct(StorageProduct product)
        {
            productDao.addProduct(product);
        }

        public void deleteProduct(long id)
        {
            productDao.deleteProduct(id);
        }
    }
}
