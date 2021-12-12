using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Common;
using Presentation.Views;
using Services;
using Model.Repositories;

namespace Presentation.Presenters
{
    public class LoginPresenter: IPresenter
    {
        private ILoginView _view;
        private AuthorizationService _loginUser;
        private ClientService _client;
       
        public LoginPresenter(ILoginView view)
        {
            this._view = view;
            this._loginUser = new AuthorizationService();
            this._client = new ClientService();
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
