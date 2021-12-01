using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Common;
using Presentation.Views;
using Model.Services;
using Model.Repositories;

namespace Presentation.Presenters
{
    public class LoginPresenter: IPresenter
    {
        private ILoginView _view;
        private IAuthorizationCustomer _loginUser;
       

       
        public LoginPresenter(ILoginView view,IAuthorizationCustomer loginUser)
        {
            this._view = view;
            this._loginUser = loginUser;
            
        }

        public void Start()
        {
            _view.Show();
        }

        public void ClientLogin()
        {
            Start();
            _view.ShowMessage("Вы вошли в систему как " + _view.ClientName);

        }
      
        public void Login()
        {
            //if (_view.Password == "123" && _view.Username == "PM")
            //{

            //    _view.PurchasingManager = true;
            //    Start();
            //}

            //else if (_view.Password == "321" && _view.Username == "AM")
            //{
            //    _view.AccountManager = true;
            //    Start();
            //}
            _loginUser.Password = _view.Password;
            _loginUser.UserName = _view.Username;
            if (_loginUser.Authorization(this._loginUser))
            {
                _loginUser.CheckRole(this._loginUser);
                _view.PurchasingManager = _loginUser.PurchasingManager;
                _view.AccountManager = _loginUser.AccountManager;
                Start();
            }
            else
            {
                _view.ShowMessage("Неверно, проверьте логин или пароль");
            }
        }

        public void AddClient()
        {
            Client client = new Client(_view.ClientName);
        }
    }
}
