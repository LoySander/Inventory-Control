using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAccountingSystem;

namespace Model.Repositories.DAO
{
    internal interface IProductDao
    {
        List<Product> getAllProducts();
        Product GetProduct(long id);
        void addProduct(Product order);
        void deleteProduct(long id);
    }
}
