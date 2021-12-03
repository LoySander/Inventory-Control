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
        private IAuthorizationClient _client;
       
        public LoginPresenter(ILoginView view,IAuthorizationCustomer loginUser, IAuthorizationClient client)
        {
            this._view = view;
            this._loginUser = loginUser;
            this._client = client;
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

            _loginUser.Password = _view.Password;
            _loginUser.UserName = _view.Username;
            if (_loginUser.Authorization(this._loginUser))
            {
                _loginUser.CheckRole(this._loginUser);
                Start();
            }
            else
            {
                _view.ShowMessage("Неверно, проверьте логин или пароль");
            }
        }

        public void AddClient(string name)
        {
            _client.Add(name);
            _view.AddCustomer(_client.ClientName);
        }
     
    }
}
