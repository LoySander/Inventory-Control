using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Common;

namespace Presentation.Views
{
   public interface IMainView: IViewOpenClose, IViewRole
    {
        void SetWindowFromRole();
        void ShowMessage(string message);
        void OpenCatalog();
        void CheckStorage();
        void ExitCatalog();
        void CheckCourierOrder();
        void CheckProviderOrder();
        //void CheckMyOrders();
        void CheckEditing();
        void CheckProfit();

        void CheckBid();
    }
}
