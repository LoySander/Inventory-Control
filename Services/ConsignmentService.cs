using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.DAO;
using Model.Repositories.DAO;
using Model;

namespace Services
{
    public class ConsignmentService
    {
        private IConsignmentDao consignmentDao;
        private static ConsignmentService INSTANCE;

        public static ConsignmentService getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new ConsignmentService();
            return INSTANCE;
        }

        private ConsignmentService()
        {
            consignmentDao = ListСonsignmentDao.getInstance();
        }

        public List<Сonsignment> GetConsignment()
        {
            return consignmentDao.getAllConsignments();
        }
        
        public void deleteConsigment(long id)
        {
            consignmentDao.deleteConsigment(id);
        }

        public void addConsignment(Сonsignment сonsignment)
        {
            consignmentDao.addConsignment(сonsignment);
        }
  
    }
}
