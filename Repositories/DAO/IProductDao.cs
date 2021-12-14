using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAccountingSystem;

namespace Model.Repositories.DAO
{
    public interface IProductDao
    {
        List<StorageProduct> getAllProducts();
        StorageProduct GetProduct(long id);
        void addProduct(StorageProduct product);
        void deleteProduct(long id);
        void RenewAllProduct(List<StorageProduct> products);
    }
}
