using JobBoard.Models;
using JobBoard.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace JobBoard.Controllers
{
    public class AccountController : Controller
    {
        IDbService _IDbService;
        private readonly UserManager<JobBoardAccount> _userManager;
        public AccountController(IDbService IDbService, UserManager<JobBoardAccount> userManager)
        {
            _IDbService = IDbService;
            _userManager = userManager;
        }
        public async Task<IActionResult> ViewAccount(string id)
        {
            var Account = await _userManager.FindByIdAsync(id);
            if (Account == null)
            {
                return RedirectToAction("Browse","JobOffer");
            }
            

            return View(Account);
        }
        public async Task<IActionResult> DownloadResume(string id)
        {
            var Account = await _userManager.FindByIdAsync(id);
            if (Account == null)
            {
                return RedirectToAction("Browse", "JobOffer");
            }
            string path = Account.ResumePath;
            var provider = new FileExtensionContentTypeProvider();
            string type="";
            if(provider.TryGetContentType(path, out type))
            {
                var bytes = await System.IO.File.ReadAllBytesAsync(path);
                return File(bytes, type,Path.GetFileName(path));

            }
            return RedirectToAction("Browse", "JobOffer");

        }
    }
}
