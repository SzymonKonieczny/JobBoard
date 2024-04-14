// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using JobBoard.Migrations;
using JobBoard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JobBoard.Helpers;
namespace JobBoard.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<JobBoardAccount> _userManager;
        private readonly SignInManager<JobBoardAccount> _signInManager;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public IndexModel(
            UserManager<JobBoardAccount> userManager,
            SignInManager<JobBoardAccount> signInManager,
            IWebHostEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        /// 
            public string Description { get; set; }
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            /// 
            [Display(Name = "User Name")]
            public string UserName { get; set; }
            [Display(Name = "Description")]

            public string Description { get; set; }

        }

        private async Task LoadAsync(JobBoardAccount user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            Description = user.Description; 


            Input = new InputModel
            {
                UserName = userName,
                Description = Description
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile ProfilePic, IFormFile Resume)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            var username = await _userManager.GetPhoneNumberAsync(user);
            if (Input.UserName != username)
            {
                var setUsernameResult = await _userManager.SetUserNameAsync(user,Input.UserName);
                if (!setUsernameResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set UserName.";
                    return RedirectToPage();
                }
            }
            var desc = user.Description;
            if (Input.Description != desc && Input.Description!=null)
            {
                user.Description = Input.Description;
                await _userManager.UpdateAsync(user);
            }

            if (Resume != null && Resume.Length > 0)
            {
                // Access file properties
                string fileName = Resume.FileName;
                string contentType = Resume.ContentType;
                long fileSize = Resume.Length;

                string Path = getPathAndName(fileName);
                // Read file content
                using (var stream = new FileStream(Path, FileMode.Create))
                {
                    await Resume.CopyToAsync(stream);
                }
                user.ResumePath = Path;
                await _userManager.UpdateAsync(user);

            }
            if (ProfilePic != null && ProfilePic.Length > 0)
            {
                // Access file properties
                string fileName = ProfilePic.FileName;
                string contentType = ProfilePic.ContentType;
                long fileSize = ProfilePic.Length;

                string Path = getPathAndName(fileName);
                // Read file content
                using (var stream = new FileStream(Path, FileMode.Create))
                {
                    await ProfilePic.CopyToAsync(stream);
                }
                user.ProfilePicturePath = Path;
                await _userManager.UpdateAsync(user);

            }




            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAccount()
        {
            var usr = await _userManager.GetUserAsync(User);
            await _signInManager.SignOutAsync();
            await _userManager.DeleteAsync(usr);
            return RedirectToAction("Browse","JobOffers");
        }
        [NonAction]
        string getPathAndName(string fileName)
        {
        string wwwRootPath = _hostingEnvironment.WebRootPath;


        string uniqueFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_{DateTime.Now:yyyyMMddHHmmssfff}{Path.GetExtension(fileName)}";

        string uniqueFilePath = Path.Combine(wwwRootPath, "UserFiles", uniqueFileName);

        return uniqueFilePath;

        }
    }
}
