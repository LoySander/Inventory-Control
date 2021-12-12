using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Threading;

namespace Model
{
    class Role
    {

        static string[] myStringArray = { "PurchasingManager", "AccountManager", "Booker", "Deliverman",
        "Storekeeper" };

        static GenericIdentity genericIdentity;
        public string[] GetArrayRole()
        {
            return myStringArray;
        }

        public Role()
        {

        }

        public Role(string str)
        {
            genericIdentity = new GenericIdentity(str);
        }
    }
}
