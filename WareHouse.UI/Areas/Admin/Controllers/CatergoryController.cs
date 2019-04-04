using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouse.Model.Entity;
using WareHouse.UI.Areas.Admin.Models.DTO;

namespace WareHouse.UI.Areas.Admin.Controllers
{
    public class CatergoryController : BaseController
    {
        
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.CategoryName = model.CategoryName;
                category.CategoryDescription = model.CategoryDescription;
                db.Categories.Add(category);
                db.SaveChanges();
                return Redirect("Admin/Category/CategoryList");
            }
            else
            {
                return View();
            }
        }
    }
}