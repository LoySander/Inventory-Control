using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repositories.DAO
{
    public interface IBidDao
    {
        Bid getBid(int id);
        List<Bid> getAllBids();
        void addBid(Bid bid);
        void deleteBid(int id);
    }
}
