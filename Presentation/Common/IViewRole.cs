using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Common
{
    public interface IViewRole
    {
        bool PurchasingManager { get; set; }
        bool AccountManager { get; set; }
    }
}
