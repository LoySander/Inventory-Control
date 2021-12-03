using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAccountingSystem
{
    public class Product
    {
        public string NameProduct { get; set; }
        public int  WeightProduct { get; set; }
        public int CostProduct { get; set; }
        public string CountryProduct { get; set; }
        public long IdProduct{ get; set;}
        public string DescriptionProduct { get; set; }

        public ProductType type { get; set; }

    }

    public enum ProductType
    {
        Manufacture,
        Food
    }
}
