using AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoNet.Controllers
{
    public class ProductController : Controller
    {
        public static DatabaseHelper dbHelper = new DatabaseHelper();
        // GET: Product
        public ActionResult Index()
        {
            List<ProductDetails> prodDetails = dbHelper.GetProductDetails();
            return View(prodDetails);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProductDetails product)
        {
            if (ModelState.IsValid)
            {
                int dbResult = dbHelper.AddProduct(product);
                if (dbResult != 0)
                    ViewBag.Result = "Product Added Succefully";
                return View(product);
            }
            else
            {
                return View(product);
            }            
        }

        [HttpGet]
        public ActionResult Edit(int productId)
        {
            ProductDetails prodDetail = dbHelper.GetProductDetail(productId);
            return View(prodDetail);
        }

        [HttpPost]
        public ActionResult Edit(ProductDetails product)
        {
            if (ModelState.IsValid)
            {
                int dbResult = dbHelper.EditProduct(product);
                if (dbResult != 0)
                    ViewBag.Result = "Product Updated Succefully";
                return View(product);
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public ActionResult Delete(int productId)
        {
            int dbResult = dbHelper.DeleteProduct(productId);
            List<ProductDetails> prodDetails = dbHelper.GetProductDetails();            
            return View("Index", prodDetails);
        }
    }
}