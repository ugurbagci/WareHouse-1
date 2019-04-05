using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouse.Model.Entity;
using WareHouse.UI.Areas.Admin.Models.DTO;

namespace WareHouse.UI.Areas.Admin.Controllers
{
    public class AppUserController : BaseController
    {
        
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Password = model.Password;
                user.Role = model.Role;
                user.Gender = model.Gender;
                db.AppUsers.Add(user);
                db.SaveChanges();
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}