using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Models;
using TestTask.Models.Data;
using TestTask.ViewModels;

namespace TestTask.Controllers
{
    public class UsersController : Controller
    {
        private UserContext userContext = new UserContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserViewModel userViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new User
                    {
                        Name = userViewModel.Name,
                        Email = userViewModel.Email,
                        LoginDate = DateTime.Now
                    };

                    userContext.Users.Add(user);
                    userContext.SaveChanges();

                    return RedirectToAction("GetUsers");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.ToString());
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult GetUsers()
        {
            var users = userContext.Users.GroupBy(x => x.Email).ToList().Select(x => new UserViewModel()
            {
                Name = x.Select(u => u.Name).FirstOrDefault(),
                Email = x.Select(u => u.Email).FirstOrDefault(),
                LoginDate = x.Select(u => u.LoginDate).FirstOrDefault(),
                UserCount = x.Count(),
                LoginDateFormatted = String.Format("{0:t} {0:d}", x.Select(u => u.LoginDate).FirstOrDefault())
            }).ToList();

            return View(users);
        }
    }
}