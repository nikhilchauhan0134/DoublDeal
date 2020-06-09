using DealDouble.Services;
using DoubleDeal.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoubleDeal.Web.Controllers
{
    public class HomeController : Controller
    {
        AuctionService service = new AuctionService();
        public ActionResult Index()
        {
            AuctionsViewModel viewmodel = new AuctionsViewModel();
            viewmodel.PageTitle = "Home page";
            viewmodel.PageDescription = "This is Home Page";
            viewmodel.PromotedAuctions = service.GetPermotedAuction();
            viewmodel.AllAuctions = service.GetAllAuction();

           
           
            return View(viewmodel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}