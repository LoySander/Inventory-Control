using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Common;
using Presentation.Views;
using WarehouseAccountingSystem;
using Services;
using Model;

namespace Presentation.Presenters
{
    public class MainPresenter: IPresenter
    {
        private IMainView _view;
        private IAuthorizationUser _role;
        private ClientProductService clientProductService;
        private ClientOrderService clientOrderService;
        private StorageService storageService;
        private OrderProviderService providerService;
        private ConsignmentService consignmentService;
        private List<Product> orderCart;
        //private List<StorageProduct> orderCart;
        private List<OrderProvider> providerOrder;
        private List<Сonsignment> consignments;
        private BidService bidService;

        public MainPresenter(IMainView view, IAuthorizationUser role)
        {
            this._view = view;
            this._role = role;
            this.clientProductService = ClientProductService.getInstance();
            this.clientOrderService = ClientOrderService.getInstance();
            //this.orderCart = new List<StorageProduct>();
            this.orderCart = new List<Product>();
            this.providerOrder = new List<OrderProvider>();
            this.consignmentService = ConsignmentService.getInstance();
            this.providerService = OrderProviderService.getInstance();
            this.storageService = StorageService.getInstance();
            this.bidService = BidService.getInstance();
        }
        public void Start()
        {
            _view.Show();
        }

        public UserType GetRoles()
        {
            return Employee.employeeType;
        }

        public void Help()
        {
            _view.ShowMessage("Номер телефона для связи: +375 228 1337");
        }
        // когда нажимаем на просмотреть каталог, должны подгрузить данные
        public void GetCataloge()
        {
            // связь с датагрид, должны получить данные
            _view.OpenCatalog();
        }
        // когда нажимаем на просмотреть список товаров на складе, должны подгрузить данные
        public List<StorageProduct> GetStorage(ProductType type)
        {
            // связь с датагрид
            _view.CheckStorage();
            return storageService.getProducts(type);
        }

        public List<StorageProduct> GetSortedStorage(ProductType type)
        {
            return storageService.getSortedProducts(type);
        }

        public void CloseCatalog()
        {
            _view.ExitCatalog();
        }

        public List<Product> GetClientsProduct(ProductType productType)
        {
            return clientProductService.getProducts(productType);
        }

        public List<Product> AddToCart(long id)
        {
            orderCart.Add(clientProductService.GetProduct(id));
            return orderCart;
        }


        public void GetCourierOrder()
        {
            // необходимо поместить 
            _view.CheckCourierOrder();
        }

        public void CheckClientOrder()
        {
            // предоставить данные по заказам
            //_view.CheckMyOrders();
        }

        public void GetEditing()
        {
            // предоставить данные по заказам
            _view.CheckEditing();
        }

        public void GetProfit()
        {
            _view.CheckProfit();
        }

        public void GetBid()
        {
            _view.CheckBid();
        }

        public List<Product> makeOrder()
        {
            String productNames = "";
            int totalCost = 0;
            foreach (Product product in orderCart)
            {
                productNames += product.NameProduct + " ";
                totalCost += product.CostProduct;
            }
            Order order = new Order
            {
                ClientId = 1,
                NamesOfProducts = productNames,
                TotalCost = totalCost,
                StatusOrder = "Ожидает оплаты",
            };
            switch (Employee.employeeType)
            {
                case UserType.PurchasingManager:
                    order.OrderType = OrderType.provider;
                    break;
                default:
                    order.OrderType = OrderType.client;
                    break;
            }
            orderCart.Clear();
            clientOrderService.addOrder(order);
            return orderCart;
        }

        public List<Order> getClientsOrders()
        {
            return clientOrderService.GetOrders(1);
        }

        public List<OrderProvider> GetOrderProvider()
        {
            return providerService.GetOrdersProvider();
        }

        public List<Order> ChangeOrderStatus(long id, string newStatus)
        {
            clientOrderService.getOrder(id).StatusOrder = newStatus;
            return getClientsOrders();
        }

        // оптимизировать нужно
        public List<OrderProvider> ChangeOrderProviderStatus(long id, string newStatus)
        {
            clientOrderService.getOrder(id).StatusOrder = newStatus;
            return GetOrderProvider();
        }
        public List<OrderProvider> AddToCartProvider(long id)
        {
            if (providerService.CheckPayment(id))
            {

                providerOrder.Add(providerService.getOrder(id));
               
            }

            else { _view.ShowMessage("Товар не оплачен");
               
            }
            return providerOrder;
        }

        // перегрузка методов, либо var либо List<t>
        public List<OrderProvider> RemoveOrderProvider(long id)
        {
            providerService.deleteOrderProvider(id);
            return GetOrderProvider();
        }

        public List<Order> RemoveOrder(long id)
        {
            clientOrderService.deleteOrder(id);
            return clientOrderService.GetOrders(1);
        }

        public List<OrderProvider> AddProductToStorage(List<OrderProvider> orders)
        {
            //    // связь с датагрид
            //    _view.CheckStorage()
            string productNames = "";
            int totalCost = 0;
            foreach (OrderProvider orderProvider in orders)
            {
                productNames += orderProvider.NamesOfProducts + " ";
                totalCost += orderProvider.TotalCost;
            }
            StorageProduct product = new StorageProduct()
            {
                Stock = 1,
                CostProduct = 1,
                DescriptionProduct = " ",
                NameProduct = productNames,
                IdProduct = 1,
                WeightProduct = 1,
                CountryProduct = " ",
                type = ProductType.Food,
            };
            providerOrder.Clear();
            storageService.addProduct(product);
            return providerOrder;
        }

        public List<Product> AddToCourier(long orderId)
        {
            try
            {
                clientOrderService.getOrder(orderId).StatusOrder = "Передан в службу доставки";
                string productNames = "";
                foreach (Product x in orderCart)
                {
                    productNames += x.NameProduct + " ";
                }
                Сonsignment consignment = new Сonsignment()
                {
                    OrderId = orderId,
                    NamesProduct = productNames,
                };

                consignmentService.addConsignment(consignment);
                ReduceStock(productNames);
                
            }
            catch 
            {
                _view.ShowMessage("ТЫ ОШИБСЯ ДРУГ");
            }
            orderCart.Clear();
            return orderCart;
        }

        public List<Сonsignment> GetСonsignments()
        {
            return consignmentService.GetConsignment();
        }

        public void RemoveConsignment(long id)
        {
             consignmentService.deleteConsigment(id);
        }

        // эксперимент (изменяем количество по именам)
        public void ReduceStock(string nameProducts)
        { 
            storageService.reduceProduct(nameProducts);
        }

        public void LeaveBid(string Text)
        {
            Bid bid = new Bid();
            bid.Text = Text;
            bid.ClientId = 1;
            bid.Id = 1;
            bidService.addBid(bid);
        }
        
        public string GetBid(int clientId)
        {
            Bid bid = bidService.getBids(clientId);
            return bid.Text;
        }
    }
    
}

