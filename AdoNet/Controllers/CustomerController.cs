using AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoNet.Controllers
{
    public class CustomerController : Controller
    {
        public static DatabaseHelper dbHelper = new DatabaseHelper();
        // GET: Customer
        public ActionResult Index()
        {        
            return View(dbHelper.GetAllCustomers());
        }

        [HttpPost]
        public ActionResult Index(string CustomerId)
        {
            Customer customer = dbHelper.GetCustomer(CustomerId);
            if (customer != null)
                return View(new List<Customer>() { customer });
            else
                return View();
        }

        public ActionResult IndexDS()
        {
            return View(dbHelper.GetAllCustomersDS());
        }

        [HttpPost]
        public ActionResult IndexDS(string CustomerId)
        {
            Customer customer = dbHelper.GetCustomerDS(CustomerId);
            if (customer != null)
                return View(new List<Customer>() { customer });
            else
                return View();
        }

        public ActionResult AddDS()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDS(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (dbHelper.InsertCustomerDS(customer) > 0)
                {
                    ViewBag.Result = "Customer Added Successfully";
                    return View(customer);
                }
            }
            return View(customer);
        }

        public ActionResult EditDS(string CustomerId)
        {
            return View(dbHelper.GetCustomerDS(CustomerId));
        }

        [HttpPost]
        public ActionResult EditDS(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (dbHelper.UpdateCustomerDS(customer) > 0)
                {
                    ViewBag.Result = "Customer data Updated Successfully";
                    return View(customer);
                }
            }
            return View(customer);
        }

        public ActionResult DeleteDS(string CustomerId)
        {
            if (dbHelper.DeleteCustomerDS(CustomerId) > 0)
            {
                ViewBag.Result = "Customer data Deleted Successfully";
                return RedirectToAction("IndexDS");
            }
            return View();
        }

        [HttpGet]
        public ActionResult CustomerByDOB()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomerByDOB(string date)
        {
            return View(dbHelper.GetAllCustomersBornAfter(Convert.ToDateTime(date)));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if(dbHelper.InsertCustomer(customer) > 0)
                {
                    ViewBag.Result = "Customer Added Successfully";
                    return View(customer);
                }
            }
            return View(customer);
        }

        [HttpGet]
        public ActionResult Edit(string CustomerId)
        {
            return View(dbHelper.GetCustomer(CustomerId));
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (dbHelper.UpdateCustomer(customer) > 0)
                {
                    ViewBag.Result = "Customer data Updated Successfully";
                    return View(customer);
                }
            }
            return View(customer);
        }

        public ActionResult Delete(string CustomerId)
        {
            if(dbHelper.DeleteCustomer(CustomerId) > 0)
            {
                ViewBag.Result = "Customer data Deleted Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}