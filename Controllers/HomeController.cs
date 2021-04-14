﻿using BYU_FEG.Models;
using BYU_FEG.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BYU_FEG.Controllers
{
    public class HomeController : Controller
    {
        public int PageSize = 10;
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        //public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //    _logger = logger;
        //}



        private BYUFEGContext context { get; set; }

        public void updateViewbag()
        {
            ViewBag.Burials = context.Burial.Select(b => new SelectListItem() { Text = $"{b.BurialLocationNs} {b.LowPairNs}/{b.HighPairNs} {b.BurialLocationEw} {b.LowPairEw}/{b.HighPairEw} {b.BurialSubplot}", Value = b.BurialId.ToString() });
            var genders = context.Byufeg.Select(b => b.GenderBodyCol).Distinct();
            ViewBag.Genders = new SelectList(genders);
            var haircolor = context.Byufeg.Select(b => b.HairColor).Distinct();
            ViewBag.HairColors = new SelectList(haircolor);
            var hd = context.Byufeg.Select(b => b.HeadDirection).Distinct();
            ViewBag.HeadDirections = new SelectList(hd);
        }

        public UserPermission findUserPermissions(string username)
        {
            
            UserPermission userPermission = context.UserPermission.FirstOrDefault(u => u.UserName == username);
            return userPermission;
        }

        public HomeController(BYUFEGContext con, ILogger<HomeController> logger, IConfiguration configuration)
        {
            context = con;
            _configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(context.Byufeg);
        }

        //public IActionResult Data()
        //{
        //    return View(context.Byufeg);
        //}

        [HttpGet]
        public IActionResult Data(int page = 1)
        {
            updateViewbag();

            IEnumerable<Byufeg> objs = context.Byufeg.OrderBy(b => b.ByufegId);

            return View(
                 new ResultListViewModel
                 {
                     bodies = objs.Skip((page - 1) * PageSize).Take(PageSize),

                     PagingInfo = new PagingInfo
                     {
                         CurrentPage = page,
                         ItemsPerPage = PageSize,
                         TotalNumItems = objs.Count(),

                     },



                 }



               );
        }

        [HttpPost]
        public IActionResult Data(ByufegFilter bf, int page = 1)
        {
            updateViewbag();
            IEnumerable<Byufeg> objs = context.Byufeg.Where(
                b => (bf.burial == null || b.BurialId == bf.burial) &&
                     (bf.burialdepth == null || b.BurialDepth == bf.burialdepth) &&
                     (string.IsNullOrEmpty(bf.burialsituation) || b.BurialSituation.ToLower().Contains(bf.burialsituation.ToLower())) &&
                     (bf.lengthofremains == null || b.LengthOfRemains == bf.lengthofremains) &&
                     (string.IsNullOrEmpty(bf.gender) || b.GenderBodyCol == bf.gender) &&
                     (string.IsNullOrEmpty(bf.haircolor) || b.HairColor == bf.haircolor) &&
                     (string.IsNullOrEmpty(bf.itemtaken) || ((bf.itemtaken == "False" && b.HairTaken == "False" && b.ToothTaken == "False" && b.BoneTaken == "False" && b.TextileTaken == "False" && b.SoftTissueTaken == "False") || (bf.itemtaken == "True" && (b.HairTaken == "True" || b.ToothTaken == "True" || b.BoneTaken == "True" || b.TextileTaken == "True" || b.SoftTissueTaken == "True")))) &&
                     (string.IsNullOrEmpty(bf.hasartifact) || b.ArtifactFound == bf.hasartifact) &&
                     (string.IsNullOrEmpty(bf.headdirection) || b.HeadDirection == bf.headdirection) &&
                     (bf.estimatedage == null || b.EstimateAge == bf.estimatedage) &&
                     (bf.estimatedheight == null || b.EstimateLivingStature == bf.estimatedheight) &&
                     (b.DateFound == null || b.DateFound >= bf.datefoundbegin) &&
                     (b.DateFound == null || b.DateFound <= bf.datefoundend)

                );
            ViewBag.Filter = bf;
            return View(
              new ResultListViewModel
              {
                  bodies = objs.Skip((page - 1) * PageSize).Take(PageSize),

                  PagingInfo = new PagingInfo
                  {
                      CurrentPage = page,
                      ItemsPerPage = PageSize,
                      TotalNumItems = objs.Count(),
                      filter = bf
                  },



              }



    ); ;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult AddRecord()
        {
            ViewBag.Burials = context.Burial.Select(b => new SelectListItem() { Text= $"{b.BurialLocationNs} {b.LowPairNs}/{b.HighPairNs} {b.BurialLocationEw} {b.LowPairEw}/{b.HighPairEw} {b.BurialSubplot}",Value=b.BurialId.ToString() });
            ViewBag.Update = false;

            return View();
        }

        [HttpPost] //details view
        public IActionResult ByufegDetails(int ByufegId)
        {
            //FIRST TRY
            //Byufeg byufeg = context.Byufeg.Find(ByufegId);
            //return View("Details", byufeg);

            //SECOND TRY
            //var Byufeg = new Byufeg() { };
            //var Burial = new Burial() { };
            //var Attachment = new Attachment() { };
            //var DetailsViewModel = new DetailsViewModel
            //{
            //    byufeg = Byufeg,
            //    burial = Burial,
            //    attachment = Attachment
            //};

            //return View("Details", DetailsViewModel);

            //THIRD TRY
            var byufeg = context.Byufeg.FirstOrDefault(x => x.ByufegId == ByufegId);
            return View(new DetailsViewModel
            {
                byufeg = byufeg,
                attachment = context.Attachment.Where(x => x.ByufegId == ByufegId),
                burial = context.Burial.FirstOrDefault(x => x.BurialId == byufeg.BurialId)
            });
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult AddRecord(Byufeg byufeg)
        {
            if (ModelState.IsValid)
            {
                context.Byufeg.Add(byufeg);
                context.SaveChanges();
                ViewBag.BYUFEGID = byufeg.ByufegId;
                return View("FileUploadForm");
            }
            else
                return View();
        }
        [Authorize(Roles = "User")]
        [HttpPost] //passes the move information into the update view
        public IActionResult ByufegUpdate(int ByufegId)
        {
            ViewBag.Update = true;
            var byufeg = context.Byufeg.FirstOrDefault(m => m.ByufegId == ByufegId);
            ViewBag.Burials = context.Burial.Select(b => new SelectListItem() { Text = $"{b.BurialLocationNs} {b.LowPairNs}/{b.HighPairNs} {b.BurialLocationEw} {b.LowPairEw}/{b.HighPairEw} {b.BurialSubplot}", Value = b.BurialId.ToString() });
            return View("AddRecord", byufeg);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult ByufegDelete(int ByufegId)
        {
            var byufeg = context.Byufeg.FirstOrDefault(m => m.ByufegId == ByufegId);
            context.Byufeg.Remove(byufeg);
            context.SaveChanges();
            return RedirectToAction("Data");
        }

        [Authorize(Roles = "User")]
        [HttpPost] //updates the form response and displays the updated movie list
        public IActionResult UpdateRecord(Byufeg byufeg)
        {
            if (ModelState.IsValid)
            {
                //Update database
                context.Byufeg.Update(byufeg);
                context.SaveChanges();
            }
            return RedirectToAction("Data", context.Byufeg);
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult BurialForm()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult BurialForm(Burial burial)
        {
            if (ModelState.IsValid)
            {
                burial.BurialConcat = $"{burial.BurialLocationNs}{burial.LowPairNs}{burial.HighPairNs}{burial.BurialLocationEw}{burial.LowPairEw}{burial.HighPairEw}{burial.BurialSubplot}";
                context.Burial.Add(burial);
                context.SaveChanges();
                return RedirectToAction("AddRecord");
            }
            else
                return View();
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult FileUploadForm(int byufegId)
        {
            ViewBag.BYUFEGID = byufegId;

            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> FileUploadForm(FileUploadFormModal FileUpload, string attachmentCategory, string attachmentDescription, int byufegId)
        {
            /*using (var stream = FileUpload.FormFile.OpenReadStream())
            {
                var file = new FormFile(stream, 0, stream.Length, null, FileUpload.FormFile.FileName);
                await S3File.UploadImage();
            }*/

            using (var memoryStream = new MemoryStream())
            {
                await FileUpload.FormFile.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    await S3File.UploadImage(FileUpload.FormFile);
                    var name = FileUpload.FormFile.FileName.Replace(" ", "");
                    context.Attachment.Add(new Attachment()
                    {
                        ByufegId = byufegId,
                        Description = attachmentDescription,
                        Category = attachmentCategory,
                        AttachmentUrl = $"https://elasticbeanstalk-us-east-1-453718841465.s3.amazonaws.com/{name}"
                    });

                    context.SaveChanges();
                    //await S3File.UploadImage(memoryStream); old method
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }

            return RedirectToAction("Data");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ManageRoles()
        {
            IEnumerable<UserPermission> userPermissions = context.UserPermission.OrderBy(u => u.Id);
            return View(userPermissions);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult RemoveUserPermission(int Id)
        {
            // Use the Id to remove the userPermission from the database and then save.
            UserPermission userPermission = context.UserPermission.FirstOrDefault(u => u.Id == Id);
            context.UserPermission.Remove(userPermission);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admin")]
        public IActionResult UserPermissionEdit(int Id)
        {
            UserPermission up = context.UserPermission.FirstOrDefault(u => u.Id == Id);
            return View("UserPermissionNew", up);
            
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UserPermissionNew()
        {
            // Add db list of roles
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UserPermissionNew(UserPermission userPermission)
        {
            if (ModelState.IsValid)
            {
                context.UserPermission.Update(userPermission);
                context.SaveChanges();
                return RedirectToAction("ManageRoles");

            }

           return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmulateUserAsync(string username)
        {

            List<String> roles = new List<string>();
            UserPermission userPermission = findUserPermissions(username);
            ClaimsPrincipal principal = new ClaimsPrincipal();
            if (userPermission!=null) { 
            if (userPermission.IsResearcher)
            {
                roles.Add("User");
            };
            if (userPermission.IsAdmin)
            {
                roles.Add("Admin");
            }
            };

            
            // Hard coded roles.
            // string[] roles = new[]{ "User", "Admin" };

            // `AddClaim` is not available directly from `context.Principal.Identity`.
            // We can add a new empty identity with the roles we want to the principal. 
            var identity = new ClaimsIdentity("Custom");

            foreach (var role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            identity.AddClaim(new Claim(JwtRegisteredClaimNames.UniqueName, username));
            
            principal.AddIdentity(identity);
            
            

            await AuthenticationHttpContextExtensions.SignInAsync(this.HttpContext, "Cookies", principal);

            

            // CookieOptions option = new CookieOptions();


            //  option.Expires = DateTime.Now.AddMinutes(1000);


            //Response.Cookies.Append(".AspNetCore.CasLogin", principal.ToString(), option);

            return RedirectToAction("Index");
        }

        [HttpGet("access-denied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet("login")]
        public async Task Login(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl)) { returnUrl = "/"; };
            var props = new AuthenticationProperties { RedirectUri = returnUrl };
            await HttpContext.ChallengeAsync("CAS", props);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            // Removes the user's auth cookie for this site and domain. 
            await HttpContext.SignOutAsync();

            // Do a full CAS logout.  
            // This removes the user's CAS auth cookie from the CAS domain.
            return Redirect($"{_configuration["CasBaseUrl"]}/logout"+ "?url=https://byufeg.demarsweb.com/");

            // Send them back to the home page.  
            // The user will remain signed into CAS. This means that if they again 
            // click to `AuthorizedPage`, they would be sent to `login` and challenged,
            // but the CAS login would be transparent/instant.
            //return RedirectToAction("Index");
        }
    }
}
