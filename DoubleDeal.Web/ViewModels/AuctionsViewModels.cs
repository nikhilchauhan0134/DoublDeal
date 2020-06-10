using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoubleDeal.Web.ViewModels
{
    public class AuctionsListingViewModel : PageViewModel
    {
        public List<Auction> Auctions { get; set; }
    }

    public class AuctionsViewModel:PageViewModel
    {
        public List<Auction> AllAuctions { get; set; }
        public List<Auction> PromotedAuctions { get; set; }
    }
    public class AuctionsDetailsViewModel : PageViewModel
    {
        public  Auction Auction { get; set; }
    }
    public class  CreateAuctionsViewModel : PageViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public decimal ActualAmount { get; set; }
        public DateTime StaringTime { get; set; }
        public DateTime EndTime { get; set; }
        public string AuctionPictures { get; set; }
    }


}