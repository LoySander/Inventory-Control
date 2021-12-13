using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAccountingSystem;

namespace Model
{
  public  class OrderProvider
    {
        public long Id { get; set; }
        public string NamesOfProducts { get; set; }
        public int TotalCost { get; set; }
        public string PaymentProduct { get; set; }
    }
}
