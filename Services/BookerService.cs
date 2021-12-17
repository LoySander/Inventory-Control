using Model.Repositories.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAccountingSystem;

namespace Services
{
    public class BookerService
    {
        private IOrderDao orderDao;

        public BookerService()
        {
            orderDao = ListOrderDao.getInstance();
        }

        public int calculateIncome()
        {
            return orderDao.getAllOrders()
                .Where(order => order.OrderType == OrderType.client
                    && (order.StatusOrder.Equals("Оплачено")
                    || order.StatusOrder.Equals("Передан в службу доставки")
                    || order.StatusOrder.Equals("Доставлен")))
                .Sum(order => order.TotalCost);
        }

        public int calculateCosts()
        {
            return orderDao.getAllOrders()
                .Where(order => order.OrderType == OrderType.provider 
                    && order.StatusOrder.Equals("Оплачено"))
                .Sum(order => order.TotalCost);
        }
    }
}
