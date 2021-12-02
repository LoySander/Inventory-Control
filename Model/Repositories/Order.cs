using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAccountingSystem
{
    public class Order
    {
        public long Id { get; set; }
        public string NameProduct { get; set; }
        public int CostProduct { get; set; }
        public int IdProduct { get; set; }
        public string PaymentProduct { get; set; }
    }
}
