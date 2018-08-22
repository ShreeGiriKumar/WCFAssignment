using AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoNet.Controllers
{
    public class CategoryController : Controller
    {
        public static DatabaseHelper dbHelper = new DatabaseHelper();

        // GET: Category
        public ActionResult Index()
        {
            CategoryDisplay categoryDisplay = new CategoryDisplay();
            categoryDisplay.SearchByOptions = GetSearchByOptions();
            return View(categoryDisplay);
        }

        [HttpPost]
        public ActionResult Index(CategoryDisplay input)
        {
            CategoryDisplay categoryDisplay = new CategoryDisplay();
            categoryDisplay.Categories = dbHelper.GetCategory(input.SearchKey, input.SearchBy);
            categoryDisplay.SearchByOptions = GetSearchByOptions();
            return View(categoryDisplay);
        }

        [HttpGet]
        public ActionResult Edit(int categoryCode)
        {
            ViewBag.OldCategoryCode = categoryCode;
            Category category = dbHelper.GetCategoryByCode(categoryCode);
            return View(category);
        }


        [HttpPost]
        public ActionResult Edit(FormCollection formData, Category category)
        {
            if (ModelState.IsValid)
            {
               int dbResult = dbHelper.UpdateCategory(category, int.Parse(formData["hdnCategoryCode"]));
                if(dbResult > 0)
                    ViewBag.Result = "Category Updated Succefully";

                ViewBag.OldCategoryCode = int.Parse(formData["hdnCategoryCode"]);
            }
            return View(category);
        }

        private List<SelectListItem> GetSearchByOptions()
        {
            return new List<SelectListItem>()
            {                
                new SelectListItem{ Selected = false, Text="Division", Value = "Division" },
                new SelectListItem{ Selected = false, Text="Region", Value = "Region" },
                new SelectListItem{ Selected = false, Text="Supplier ID", Value = "Supplier_Id" },
                new SelectListItem{ Selected = false, Text="Supplier Name", Value = "Supplier_Name" },
                new SelectListItem{ Selected = false, Text="Category Code", Value = "Category_Code" },
            };
        }
    }
}