using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repositories.DAO
{
   public interface IConsignmentDao
    {
        List<Сonsignment> getAllConsignments();
        Сonsignment GetConsignment(long id);
        void addConsignment(Сonsignment сonsignment);
        void deleteConsigment(long id);
    }
}
