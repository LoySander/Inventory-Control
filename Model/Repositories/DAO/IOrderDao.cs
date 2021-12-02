using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAccountingSystem;

namespace Model.Repositories.DAO
{
    public interface IOrderDao
    {
        List<Order> getAllOrders();
        Order GetOrder(long id);
        void addOrder(Order order);
        void deleteOrder(long id);
    }
}
