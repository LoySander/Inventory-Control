using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAccountingSystem
{
    public class Order: OrderProvider
    {
        public int ClientId { get; set; }
        public int IdProduct { get; set; }
    }
}
