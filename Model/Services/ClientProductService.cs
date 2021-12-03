using Model.Repositories.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAccountingSystem;

namespace Model.Services
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
            List<Product> products = productDao.getAllProducts();
            return products.Where(product => product.type == type).ToList();
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
}
