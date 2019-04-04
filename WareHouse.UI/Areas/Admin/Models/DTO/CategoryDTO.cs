using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WareHouse.UI.Areas.Admin.Models.DTO
{
    public class CategoryDTO:BaseDTO
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}