using JobBoard.Models;
using JobBoard.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;


namespace JobBoard.Controllers
{
    public class JobOffersController : Controller
    {
        IDbService _IDbService;
    //   private readonly SignInManager<JobBoardAccount> _signInManager;
        private readonly UserManager<JobBoardAccount> _userManager;
        public JobOffersController(IDbService IDbService, UserManager<JobBoardAccount> userManager) {
                _userManager = userManager;
            _IDbService = IDbService;
        }
        // GET: JobOffers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Browse()
        {
            var Offers = _IDbService.GetOffersQueryable().Include(of => of.OwnedBy).ToList();

            return View(Offers);
        }
        public async Task<ActionResult> BrowseOwned()
        {

            var userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var usr =_userManager.Users.Where(u=>u.Id== userID).Include(u=>u.Offers).FirstOrDefault();
           
            
            //var list = Offers
            return View(usr.Offers.ToList());
        }
        public ActionResult Add()
        {
            var Tags = _IDbService.GetTags();
            ViewData["Tags"] = Tags;


            var TagsSelected = new List<bool>(new bool[Tags.Count]);
            TempData["TagsSelected"] = TagsSelected;
           // TempData["TagsSelected"] = new SelectList(Tags);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(JobOffer offer)
        {
            try
            {
                //var TagsSelected = (List<bool>)TempData["TagsSelected"];
                var Tags  =_IDbService.GetTags();
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
                var usr = await _userManager.GetUserAsync(User);
                if(usr == null)
                {
                    return RedirectToAction("Browse");

                }
                offer.OwnedBy = usr;
             //usr.Offers.Add(offer);

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
