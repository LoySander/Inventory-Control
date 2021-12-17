using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Repositories.DAO
{
  public class ListСonsignmentDao: IConsignmentDao
    {
       
        private List<Сonsignment> consignmentList;
        private static ListСonsignmentDao INSTANCE;

        static public ListСonsignmentDao getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new ListСonsignmentDao();
            return INSTANCE;
        }
        private ListСonsignmentDao()
        {
            consignmentList = new List<Сonsignment>();

        }
        public void addConsignment(Сonsignment сonsignment)
        {
            consignmentList.Add(сonsignment);
        }
        public void deleteConsigment(long id)
        {
            consignmentList.Remove(GetConsignment(id));
        }
        public List<Сonsignment> getAllConsignments()
        {
            return new List<Сonsignment>(consignmentList);
        }
        public Сonsignment GetConsignment(long id)
        {
            return consignmentList.Where(order => order.OrderId == id).First();
        }
    }
}
