using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAccountingSystem
{
    public class StorageProduct:Product
    {
        public int Stock { get; set; }
        public ProductType type { get; set; }
    }

    public enum ProductType
    {
        Manufacture,
        Food
    }
}
