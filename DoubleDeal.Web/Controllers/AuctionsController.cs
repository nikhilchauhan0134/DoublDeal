using DealDouble.Entities;
using DealDouble.Services;
using DoubleDeal.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoubleDeal.Web.Controllers
{
    public class AuctionsController : Controller
    {
        AuctionService service = new AuctionService();
        // GET: Auctions
        public ActionResult Index()
        {
            AuctionsListingViewModel model = new AuctionsListingViewModel(); 
            model.Auctions= service.GetAllAuction();
            model.PageTitle = "Autions";
            model.PageDescription ="Auction Listing Page";
            return View(model);
        
            
        }


        public ActionResult Listing()
        {
            AuctionsListingViewModel model = new AuctionsListingViewModel();
            model.Auctions = service.GetAllAuction();
            return PartialView(model);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Auction auction)
        {
            
            service.SaveAuction(auction);
            return RedirectToAction("Listing");
        }
        [HttpGet]
        public ActionResult Edit(int ID)  
        {
            
            var auction = service.GetAuctionByID(ID);
            return PartialView(auction);
        }
        [HttpPost]
        public ActionResult Edit(Auction auction)
        {
            
            service.updateAuction(auction);
            return RedirectToAction("Listing");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            
            var auction = service.GetAuctionByID(ID);
            return View(auction);
        }
        [HttpPost]
        public ActionResult Delete(Auction auction)
        {
            
            service.DeleteAuction(auction);
            return RedirectToAction("Listing");
        }
        [HttpGet]
        public ActionResult Details(int ID)
        {
            var auction = service.GetAuctionByID(ID);
            return View(auction);

        }
    }
}