using Model;
using Repositories.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BidService
    {
        private IBidDao bidDao;
        private static BidService INSTANCE;

        public static BidService getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new BidService();
            return INSTANCE;
        }
        private BidService()
        {
            bidDao = ListBidDao.getInstance();
        }

        public void addBid(Bid bid)
        {
            bidDao.addBid(bid);
        }

        public Bid getBid(int Id)
        {
            return bidDao.getBid(Id);
        }
        public List<Bid> getAllBids()
        {
            return bidDao.getAllBids();
        }


    }
}
