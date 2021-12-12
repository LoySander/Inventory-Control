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
        public int ClientId { get; set; }
        public string NamesOfProducts { get; set; }
        public int TotalCost { get; set; }
        public int IdProduct { get; set; }
        public string PaymentProduct { get; set; }
    }
}
