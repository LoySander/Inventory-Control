using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repositories.DAO
{
    public class ListBidDao:IBidDao
    {
        private int currentId = 1;
        List<Bid> Bids = new List<Bid>();
        private static ListBidDao INSTANCE;

        static public ListBidDao getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new ListBidDao();
            return INSTANCE;
        }

        private ListBidDao()
        {
            Bids = new List<Bid>();
        }

        public Bid getBid(int id)
        {
            return Bids.Where(bid => bid.Id == id).First();
        }

        public List<Bid> getAllBids()
        {
            return Bids;
        }

        public void addBid(Bid bid)
        {
            bid.Id = currentId++;
            Bids.Add(bid);
        }

        public void deleteBid(int id)
        {
            Bids.Remove(getBid(id));
        }
    }
}
