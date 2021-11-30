using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Common;
using Presentation.Views;

namespace Presentation.Presenters
{
    public class LoginPresenter: IPresenter
    {
        private ILoginView _view;
        public LoginPresenter(ILoginView view)
        {
            this._view = view; 
        }

        public void Start()
        {
            
        }

        public void ClientLogin()
        {
            //_view.Show();
        }
      
        public void Login()
        {
            if (_view.Password == "123" && _view.Username == "PM")
            {
               
                _view.PurchasingManager = true;
                _view.Show();
            }

            else if (_view.Password == "321" && _view.Username == "AM")
            {
                _view.AccountManager = true;
                _view.Show();
            }
            else
            {
                _view.Error();
            }
        }
    }
}
