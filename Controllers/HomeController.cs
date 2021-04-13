using BYU_FEG.Models;
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
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BYU_FEG.Controllers
{
    public class HomeController : Controller
    {
        public int PageSize = 25;
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        //public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //    _logger = logger;
        //}

        private BYUFEGContext context { get; set; }

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

        //public IActionResult Data(string filters, int page = 1)
        //{
        //    string[] filterArray = filters.Split("_");
        //    IEnumerable<Byufeg> objs = context.Byufeg.OrderBy(b => b.ActivityId);

        //    foreach (string f in filterArray)
        //    {
        //        string[] vs = f.Split("-");
        //        IEnumerable<Byufeg> filterobjs = context.Byufeg.Where(b => vs[0] == vs[1]);
        //        objs.Intersect(filterobjs);
        //    }



        //    return View(
        //          new ResultListViewModel
        //          {
        //              bodies=objs,

        //              PagingInfo = new PagingInfo
        //              {
        //                  CurrentPage = page,
        //                  ItemsPerPage = PageSize,
        //                  TotalNumItems = objs.Count(),
        //                  context = context
        //              },

        //              CurrentFilters = filterArray,
                     
        //          }



        //        );
        //}

        [HttpGet]
        public IActionResult AddRecord()
        {
            ViewBag.Burials = context.Burial.Select(b => new SelectListItem() { Text= $"{b.BurialLocationNs} {b.LowPairNs}/{b.HighPairNs} {b.BurialLocationEw} {b.LowPairEw}/{b.HighPairEw} {b.BurialSubplot}",Value=b.BurialId.ToString() });
            //ViewBag.Activities = context.Activity.Select(a => new SelectListItem() { Text = a.Date, Value = a.ActivityId.ToString() });

            return View();
        }

        [HttpPost]
        public IActionResult AddRecord(Byufeg byufeg)
        {
            if (ModelState.IsValid)
            {
                context.Byufeg.Add(byufeg);
                context.SaveChanges();
                return RedirectToAction("Data");
            }
            else
                return View();
        }

        public async Task<IActionResult> FileUploadForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FileUploadForm(FileUploadFormModal FileUpload)
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
                        AttachmentUrl = $"https://elasticbeanstalk-us-east-1-453718841465.s3.amazonaws.com/{name}"
                    });
                    //await S3File.UploadImage(memoryStream); old method
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }

            return View();
        }

        public IActionResult ManageRoles()
        {
            IEnumerable<UserPermission> userPermissions = context.UserPermission.OrderBy(u => u.Id);
            return View(userPermissions);
        }

        public IActionResult RemoveUserPermission(int Id)
        {
            // Use the Id to remove the userPermission from the database and then save.
            UserPermission userPermission = context.UserPermission.FirstOrDefault(u => u.Id == Id);
            context.UserPermission.Remove(userPermission);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult UserPermissionEdit(int Id)
        {
            UserPermission up = context.UserPermission.FirstOrDefault(u => u.Id == Id);
            return View("UserPermissionNew", up);
            
        }

        [HttpGet]
        public IActionResult UserPermissionNew()
        {
            // Add db list of roles
            return View();
        }

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
        public IActionResult EmulateUser(string netid)
        {
            

            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
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
            return Redirect($"{_configuration["CasBaseUrl"]}/logout");

            // Send them back to the home page.  
            // The user will remain signed into CAS. This means that if they again 
            // click to `AuthorizedPage`, they would be sent to `login` and challenged,
            // but the CAS login would be transparent/instant.
            //return RedirectToAction("Index");
        }
    }
}
