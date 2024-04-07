using JobBoard.Models;
using JobBoard.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var Tags = _IDbService.GetTags(new SearchOptions());
            ViewData["Tags"] = Tags;


            //var TagsSelected = new List<bool>(new bool[Tags.Count]);
            //TempData["TagsSelected"] = TagsSelected;
            TempData["TagsSelected"] = new SelectList(Tags);
            return View();
        }

        [HttpPost]
        public ActionResult Add(JobOffer offer)
        {
            try
            {
                //var TagsSelected = (List<bool>)TempData["TagsSelected"];
                var Tags  =_IDbService.GetTags(new SearchOptions());
                //var TagsSelected = (List<SelectList>)ViewData["tags"];
                //
                //offer.Tags.Clear();
                //if (TagsSelected != null)
                //{
                //    for (int i = 0; i < TagsSelected.Count; i++)
                //    {
                //        if (TagsSelected[i]) offer.Tags.Add(Tags[i]);
                //    }
                //}

                offer.Tags.Clear();
                
                var TagsSelected = (SelectList)ViewData["tags"];

                foreach (Tag tag in TagsSelected.SelectedValues) 
                {
                    if(Tags.FindAll(t => t.Id == tag.Id).Count > 0)
                    {
                        offer.Tags.Add(tag);
                    }

                }


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



        public ActionResult AddTags()
        {
            _IDbService.AddTag(new Tag("Tag1"));
            _IDbService.AddTag(new Tag("Tag2"));
            _IDbService.AddTag(new Tag("Tag3"));
            _IDbService.AddTag(new Tag("Tag4"));
            _IDbService.AddTag(new Tag("Tag5"));
            _IDbService.AddTag(new Tag("Tag6"));
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
