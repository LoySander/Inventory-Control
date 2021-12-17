using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Common;

namespace Presentation.Views
{
   public interface IMainView: IViewOpenClose
    {
        void SetWindowFromRole();
        void ShowMessage(string message);
        void ExitCatalog();
        //void CheckProviderOrder();
        //void CheckMyOrders();
    }
}
