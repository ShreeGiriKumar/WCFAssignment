using AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoNet.Controllers
{
    public class SupplierController : Controller
    {
        public static DatabaseHelper dbHelper = new DatabaseHelper();
        // GET: Supplier
        public ActionResult Index()
        {
            List<SupplierInfo> suppliersInfo = dbHelper.GetSuppliersInfo();
            return View(suppliersInfo);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(SupplierInfo supplierInfo)
        {
            if (ModelState.IsValid)
            {
                int dbResult = dbHelper.AddSupplier(supplierInfo);
                if (dbResult != 0)
                    ViewBag.Result = "Product Added Succefully";
                return View(supplierInfo);
            }
            else
            {
                return View(supplierInfo);
            }
        }

        [HttpGet]
        public ActionResult Edit(int supplierId)
        {
            SupplierInfo supplierInfo = dbHelper.GetSupplierInfo(supplierId);
            return View(supplierInfo);
        }

        [HttpPost]
        public ActionResult Edit(SupplierInfo supplierInfo)
        {
            if (ModelState.IsValid)
            {
                int dbResult = dbHelper.EditSupplier(supplierInfo);
                if (dbResult != 0)
                    ViewBag.Result = "Supplier Updated Succefully";
                return View(supplierInfo);
            }
            else
            {
                return View(supplierInfo);
            }
        }

        [HttpGet]
        public ActionResult Delete(int supplierId)
        {
            int dbResult = dbHelper.DeleteSupplier(supplierId);
            List<SupplierInfo> suppliersInfo = dbHelper.GetSuppliersInfo();
            return View("Index", suppliersInfo);
        }
    }
}