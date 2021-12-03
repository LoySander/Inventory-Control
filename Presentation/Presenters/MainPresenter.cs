using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Common;
using Presentation.Views;
using Model.Services;
using Model.Repositories;
using WarehouseAccountingSystem;

namespace Presentation.Presenters
{
    public class MainPresenter: IPresenter
    {
        private IMainView _view;
        private IAuthorizationCustomer _role;
        private Employee employee;
        private ClientProductService clientProductService;
        private List<Product> cart;
        public MainPresenter(IMainView view, IAuthorizationCustomer role)
        {
            this._view = view;
            this._role = role;
            this.clientProductService = ClientProductService.getInstance();
            this.cart = new List<Product>();
        }
        public void Start()
        {
            _view.Show();
        }

        public void GetRoles()
        {
            _view.AccountManager = _role.AccountManager;
            _view.PurchasingManager = _role.PurchasingManager;
            _view.SetWindowFromRole();
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
        public void GetStorage()
        { 
            // связь с датагрид
            _view.CheckStorage();
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
            cart.Add(clientProductService.GetProduct(id));
            return cart;
        }

        public void GetCourierOrder()
        {
            // необходимо поместить 
            _view.CheckCourierOrder();
        }

        public void CheckOrderProvider() 
        {
            // необходимо предоставить данные
            _view.CheckProviderOrder();
        }

        public void CheckClientOrder()
        {
            // предоставить данные по заказам
            _view.CheckMyOrders();
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
    }
}
