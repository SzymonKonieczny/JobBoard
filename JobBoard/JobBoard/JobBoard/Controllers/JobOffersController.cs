using JobBoard.Models;
using JobBoard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using System.Xml;


namespace JobBoard.Controllers
{

    public class JobOffersController : Controller
    {
        IDbService _IDbService;
        private readonly UserManager<JobBoardAccount> _userManager;
    //   private readonly SignInManager<JobBoardAccount> _signInManager;
        public JobOffersController(IDbService IDbService, UserManager<JobBoardAccount> userManager) {
                _userManager = userManager;
            _IDbService = IDbService;
        }
        // GET: JobOffers
        public ActionResult Index()
        {
            return Redirect("Browse");
        }

        [HttpGet]
        public ActionResult Browse()
        {
            var Offers = _IDbService.GetOffersQueryable().Include(of => of.OwnedBy);
            var OffersL = Offers.ToList();
            return View(OffersL);
        }
        [HttpPost]
        public ActionResult Browse(string search)
        {
            var Offers = _IDbService.GetOffersQueryable().Include(of => of.OwnedBy).Where(o => o.Title.Contains(search));
            var OffersL = Offers.ToList();


            return View(OffersL);
        }
        [Authorize]

        public async Task<ActionResult> BrowseOwned()
        {

            var userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var usr =_userManager.Users.Where(u=>u.Id== userID).Include(u=>u.Offers).FirstOrDefault();
           
            
            //var list = Offers
            return View(usr.Offers.ToList());
        }
        [Authorize]

        public ActionResult Add()
        {
            var Tags = _IDbService.GetTags();
            ViewData["Tags"] = Tags;


          //  var TagsSelected = new List<bool>(new bool[Tags.Count]);
         //   TempData["TagsSelected"] = TagsSelected;
           // TempData["TagsSelected"] = new SelectList(Tags);
            return View();
        }
        [Authorize]

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
                    TempData["WasSuccess?"] = DbServiceActionStatus.Failure;

                    return RedirectToAction("Browse");

                }
                offer.OwnedBy = usr;

                _IDbService.AddOffer(offer);
                TempData["WasSuccess?"] = DbServiceActionStatus.Success;

                return RedirectToAction("Browse");
            }
            catch
            {
                TempData["WasSuccess?"] = DbServiceActionStatus.Failure;

                return View();
            }
        }

        [Authorize]

        public async Task<ActionResult> Delete(int id)
        {
            var Offer = _IDbService.GetOffersQueryable().Include(o => o.OwnedBy).FirstOrDefault(o => o.Id == id);
            if (Offer == null)
            {
                TempData["WasSuccess?"] = DbServiceActionStatus.Failure;

                return RedirectToAction("Browse");
            
            }
            bool isAdmin = false;
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                isAdmin = user.Email == "admin@admin.com";
            }

            if (Offer.OwnedBy.Id == _userManager.GetUserId(User) || isAdmin)
            {
                 DbServiceActionStatus resState = _IDbService.DeleteOffer(id);
                TempData["WasSuccess?"] = resState;
                return RedirectToAction("Browse");

            }

           TempData["WasSuccess?"] = DbServiceActionStatus.Failure;

            return RedirectToAction("Browse");
        }
        [Authorize]

        public async Task<ActionResult> Apply( int OfferId)
        {
            try
            {
                var Offer = _IDbService.GetOffersQueryable().Include(o => o.ApplicantsIDs).Where(o=>o.Id == OfferId).FirstOrDefault();
                Offer.ApplicantsIDs.Add(new UserApplication(_userManager.GetUserId(User)));
                _IDbService.SaveChanges();
            }
            catch
            {
                TempData["WasSuccess?"] = DbServiceActionStatus.Failure;
                return RedirectToAction("Browse");

            }


            TempData["WasSuccess?"] = DbServiceActionStatus.Success;

            return RedirectToAction("Browse");
        }
        [Authorize]

        public async Task<ActionResult> OfferDetails(int id)
        {

           var Offer = _IDbService.GetOffersQueryable().Where(o => o.Id == id)
                .Include(o => o.ApplicantsIDs).FirstOrDefault();

            if (Offer != null){

            
            var Users = await _IDbService.GetOffersQueryable().SelectMany(O => O.ApplicantsIDs)
                .Where(a => a.JobOfferId==Offer.Id)
                .Join(_userManager.Users,ua => ua.ApplicantID,us=>us.Id, (app,usr)=> new AccountWithApplications(
                    app,usr
                    )).ToListAsync();


            ViewData["Users"] = Users;

            return View(Offer);
            }
            return RedirectToAction("Browse"); 
        }


         [Authorize]
        public ActionResult Edit(int id)
        {
            var offer = _IDbService.GetOffersQueryable().Where(o => o.Id == id).FirstOrDefault();

            if (offer == null) return RedirectToAction("BrowseOwned");

            var userID = _userManager.GetUserId(User);
            
            if(offer.CompanyID == userID) return View(offer);

            else return RedirectToAction("BrowseOwned");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(JobOffer offerInput)
        {
            
        var offer = _IDbService.GetOffersQueryable().Where(o=>o.Id == offerInput.Id).FirstOrDefault();

            offer.Title = offerInput.Title;
            offer.Description = offerInput.Description;
            _IDbService.EditOffer(offer);

        return RedirectToAction("BrowseOwned");
    
        }

       

    }
}
