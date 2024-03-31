using JobBoard.Models;
using JobBoard.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace JobBoard.Controllers
{
    public class JobOffersController : Controller
    {
        IDbService _IDbService;
        public JobOffersController(IDbService IDbService) => _IDbService = IDbService;
        // GET: JobOffers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Browse()
        {
            return View(_IDbService.GetOffers(new SearchOptions()));
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(JobOffer offer)
        {
            try
            {
                _IDbService.AddOffer(offer);

                return RedirectToAction("Browse");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            DbServiceActionStatus resState = _IDbService.DeleteOffer(id);

            //TempData["FromDeleteAction?"] = true;
            TempData["WasSuccess?"] = resState;

            return RedirectToAction("Browse");
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
