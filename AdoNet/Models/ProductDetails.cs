using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoNet.Models
{
    public class ProductDetails
    {
        [Display(Name = "Product ID")]
        [Required]
        public int ProductId { get; set; }
        [Display(Name = "Product Name")]
        [Required]
        public string ProductName { get; set; }
        [Display(Name = "Supplier ID")]
        [Required]
        public int SupplierId { get; set; }
    }

    public class SupplierInfo
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ContactNo { get; set; }
        public string Email { get; set; }
    }

    public class Category
    {
        [Required]
        public int CategoryCode { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string Division { get; set; }
        public string Region { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
    }

    public class CategoryDisplay
    {
        [Display(Name ="Search By")]
        public string SearchBy { get; set; }
        public string SearchKey { get; set; }
        public List<SelectListItem> SearchByOptions { get; set; }
        public List<Category> Categories { get; set; }
        
    }

    public class Customer
    {        
        [Display(Name ="Customer ID")]
        public string CustomerId { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "DOB")]
        public DateTime DOB { get; set; }
        [Required]
        [Display(Name = "Salary")]
        public double Salary { get; set; }
    }

    public class JobOpening
    {   
        public string JobCode { get; set; }     
        public string JobDescription { get; set; }     
        public string JobRole { get; set; }
    }

    public class Employee
    {   
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public string EmployeeFirstName { get; set; }
        [Required]
        public string EmployeeLastName { get; set; }
        [Required]
        public string DepartmentID { get; set; }
    }
}