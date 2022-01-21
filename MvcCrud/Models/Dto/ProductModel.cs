using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrud.Models.Dto
{
    public class ProductModel
    {
        public List<ProductsDto> pList { get; set; }
        public Products Products { get; set; }
        public List<SelectListItem> CategoriesForDropDown { get; set; }
        public List<SelectListItem> SuppliersForDropDown { get; set; }
    }
}