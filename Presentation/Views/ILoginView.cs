using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Common;

namespace Presentation.Views
{
     public interface ILoginView: IViewOpenClose
    {
        string Username { get; }
        string Password { get; }

        string ClientName { get;}
        void AddCustomer(string name);
        void ShowMessage(string message);
    }
}
