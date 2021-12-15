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
        private AuthorizationService loginUser;
        private ClientService client;
       
        public LoginPresenter(ILoginView view)
        {
            this._view = view;
            this.loginUser = new AuthorizationService();
            this.client = new ClientService();
        }
        public void Start()
        {
            _view.Show();
        }

        public void ClientLogin()
        {
            loginUser.ClientName = _view.ClientName;
            loginUser.CheckRole(this.loginUser);
            Start();
            _view.ShowMessage("Вы вошли в систему как " + _view.ClientName);   
        }
        public void Login()
        {
            loginUser.Password = _view.Password;
            loginUser.UserName = _view.Username;
            if (loginUser.Authorization(this.loginUser))
            {
                loginUser.CheckRole(this.loginUser);
                Start();
            }
            else
            {
                _view.ShowMessage("Неверно, проверьте логин или пароль");
            }
            loginUser.Password = " ";
            loginUser.UserName = " ";
        }

        public void AddClient(string name)
        {
            loginUser.Add(name);
            _view.AddCustomer(loginUser.ClientName);
        }
     
    }
}
