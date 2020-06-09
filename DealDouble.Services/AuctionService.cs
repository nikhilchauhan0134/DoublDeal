using DealDouble.Data;
using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class AuctionService
    {
        public List<Auction> GetAllAuction()
        {
            DealDoubleContext context = new DealDoubleContext();
            return context.Auctions.ToList();
        }
        public List<Auction> GetPermotedAuction()
        {
            DealDoubleContext context = new DealDoubleContext();
            return context.Auctions.Take(4).ToList();
        }
        public Auction GetAuctionByID(int ID)
        {
            DealDoubleContext context = new DealDoubleContext();
            return context.Auctions.Find(ID);
        }
        public void SaveAuction(Auction auction)
        {
            DealDoubleContext context = new DealDoubleContext();
            context.Auctions.Add(auction);
            context.SaveChanges();
        }
        public void updateAuction(Auction auction)
        {
            DealDoubleContext context = new DealDoubleContext();
            context.Entry(auction).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteAuction(Auction auction)
        {
            DealDoubleContext context = new DealDoubleContext();
            context.Entry(auction).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
