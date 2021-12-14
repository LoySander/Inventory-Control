
using Model;
using Model.Repositories.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAccountingSystem;

namespace Services
{
   public class OrderProviderService
    {
        private IOrderDao orderDao;
        private static OrderProviderService INSTANCE;

        public static OrderProviderService getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new OrderProviderService();
            return INSTANCE;
        }

        private OrderProviderService()
        {
            orderDao = ListOrderDao.getInstance();
        }

        public List<OrderProvider> GetOrdersProvider()
        {
            List<Order> orders = orderDao.getAllOrders();
            List<OrderProvider> ordersProvider = new List<OrderProvider>();
            orders = orders.ToList();
            orders.ForEach(order =>
            {
                OrderProvider orderProvider = new OrderProvider();
                orderProvider.Id = order.Id;
                orderProvider.NamesOfProducts = order.NamesOfProducts;
                orderProvider.TotalCost = order.TotalCost;
                orderProvider.PaymentProduct = order.PaymentProduct;
                ordersProvider.Add(orderProvider);
            });
            return ordersProvider;
        }

        public void addOrder(Order order)
        {
            orderDao.addOrder(order);
        }

        public OrderProvider getOrder(long id)
        {
            return orderDao.GetOrder(id);
        }

        public bool CheckPayment(long id)
        {
            List<OrderProvider> order = new List<OrderProvider>();
            order.Add(getOrder(id));
            string str = "Оплачено";
            foreach(OrderProvider x in order)
            {
                if (x.PaymentProduct == str)
                {
                    return true;
                }
            }
            return false;

       }
        public void deleteOrderProvider(long id)
        {
            orderDao.deleteOrder(id);
        }
    }
}
