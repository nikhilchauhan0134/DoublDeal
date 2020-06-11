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
        AuctionService auctionService = new AuctionService();
        CategoriesService categoriesService = new CategoriesService();
        // GET: Auctions
        public ActionResult Index()
        {
            AuctionsListingViewModel model = new AuctionsListingViewModel(); 
            model.Auctions= auctionService.GetAllAuction();
            model.PageTitle = "Autions";
            model.PageDescription ="Auction Listing Page";
            return View(model);
        
            
        }


        public ActionResult Listing()
        {
            AuctionsListingViewModel model = new AuctionsListingViewModel();
            model.Auctions = auctionService.GetAllAuction();
            return PartialView(model);

        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateAuctionsViewModel model = new CreateAuctionsViewModel();
            model.Categories = categoriesService.GetAllCategories();

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(CreateAuctionsViewModel model)
        {
            Auction auction = new Auction();
            auction.Title = model.Title;
            auction.CategoryID = model.CategoryID;
            auction.Description = model.Description;
            auction.ActualAmount = model.ActualAmount;
            auction.StaringTime = model.StaringTime;
            auction.EndTime = model.EndTime;
            var pictureIDs = model.AuctionPictures.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries).Select(ID => int.Parse(ID)).ToList();
            auction.AuctionPictures = new List<AuctionPicture>();
            auction.AuctionPictures.AddRange(pictureIDs.Select(x => new AuctionPicture() { PictureID = x }).ToList());

            auctionService.SaveAuction(auction);
            return RedirectToAction("Listing");
        }
        [HttpGet]
        public ActionResult Edit(int ID)  
        {
            
            var auction = auctionService.GetAuctionByID(ID);
            return PartialView(auction);
        }
        [HttpPost]
        public ActionResult Edit(Auction auction)
        {
            
            auctionService.updateAuction(auction);
            return RedirectToAction("Listing");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            
            var auction = auctionService.GetAuctionByID(ID);
            return View(auction);
        }
        [HttpPost]
        public ActionResult Delete(Auction auction)
        {
            
            auctionService.DeleteAuction(auction);
            return RedirectToAction("Listing");
        }
        [HttpGet]
        public ActionResult Details(int ID)
        {
            AuctionsDetailsViewModel model = new AuctionsDetailsViewModel();
            model.Auction = auctionService.GetAuctionByID(ID);
            model.PageTitle = "Auction Details:" + model.Auction.Title;
            model.PageDescription = model.Auction.Description.Substring(0, 10);

            return View(model);

        }
    }
}