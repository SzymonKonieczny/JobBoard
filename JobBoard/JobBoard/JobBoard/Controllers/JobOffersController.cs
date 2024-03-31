using JobBoard.Models;
using JobBoard.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace JobBoard.Controllers
{
    public class JobOffersController : Controller
    {
        IJobOfferFetcher _OfferFetcher;
        public JobOffersController(IJobOfferFetcher OfferFetcher) => _OfferFetcher = OfferFetcher;
        // GET: JobOffers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Browse()
        {
            return View(_OfferFetcher.GetOffers(new SearchOptions()));
        }
        public ActionResult Add()
        {
            return View( );
        }

        [HttpPost]
        public ActionResult Add(JobOffer offer)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }







        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobOffers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
