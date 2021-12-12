using Model.Repositories.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAccountingSystem;

namespace Services
{
    public class ClientOrderService
    {
        private IOrderDao orderDao;
        private static ClientOrderService INSTANCE;

        public static ClientOrderService getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new ClientOrderService();
            return INSTANCE;
        }

        private ClientOrderService()
        {
            orderDao = ListOrderDao.getInstance();
        }

        public List<Order> GetOrders(int clientId)
        {
            return orderDao.getAllOrders().Where(order => order.ClientId == clientId).ToList();
        }

        public void addOrder(Order order)
        {
            orderDao.addOrder(order);
        }
    }
}
