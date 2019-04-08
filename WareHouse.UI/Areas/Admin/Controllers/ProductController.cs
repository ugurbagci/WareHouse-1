using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouse.Model.Entity;
using WareHouse.UI.Areas.Admin.Models.DTO;
using WareHouse.UI.Areas.Admin.Models.VM;

namespace WareHouse.UI.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        
        public ActionResult AddProduct()
        {
            List<Category> model = db.Categories.Where(x => x.Status == Model.Enum.Status.Active || x.Status == Model.Enum.Status.Updated).OrderBy(x => x.AddDate).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddProduct(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.ProductName = model.ProductName;
                product.ProductDescription = model.ProductDescription;
                product.UnitPrice = model.UnitPrice;
                product.UnitsInStock = model.UnitsInStock;
                product.CategoryID = model.CategoryID;
                db.Products.Add(product);
                db.SaveChanges();
                ViewBag.ProcessCondition = 1;
                return Redirect("/Admin/Product/ProductList");
            }
            else
            {
                ViewBag.ProcessCondition = 1;
                return View();
            }
        }

        public ActionResult ProductList()
        {
            List<ProductDTO> model = db.Products.Where(x => x.Status == Model.Enum.Status.Active || x.Status == Model.Enum.Status.Updated).Select(x => new ProductDTO
            {
                ID = x.ID,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                CategoryID = x.CategoryID,
                CategoryName = x.Category.CategoryName,
            }).ToList();

            return View(model);
        }

        public ActionResult UpdateProduct(int id)
        {
            ProductVM model = new ProductVM();
            Product product = db.Products.FirstOrDefault(x => x.ID == id);
            model.Product.ID = product.ID;
            model.Product.ProductName = product.ProductName;
            model.Product.ProductDescription = product.ProductDescription;
            model.Product.UnitPrice = product.UnitPrice;
            model.Product.UnitsInStock = product.UnitsInStock;

           List<Category> categorymodel = db.Categories.Where(x => x.Status == Model.Enum.Status.Active || x.Status == Model.Enum.Status.Updated).ToList();

            model.Categories = categorymodel;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateProduct(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                Product product = db.Products.FirstOrDefault(x => x.ID == model.ID);
                product.ProductName = model.ProductName;
                product.ProductDescription = model.ProductDescription;
                product.UnitPrice = model.UnitPrice;
                product.UnitsInStock = model.UnitsInStock;
                product.CategoryID = model.CategoryID;
                

                db.SaveChanges();
                return Redirect("/Admin/Product/ProductList");
            }
            else
            {
                return View();
            }
        }
    }
}