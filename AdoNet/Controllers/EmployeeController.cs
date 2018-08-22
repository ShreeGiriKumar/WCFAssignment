using AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoNet.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeService.EmployeeServiceClient client = new EmployeeService.EmployeeServiceClient("WSHttpBinding_IEmployeeService");
        
        [HttpGet]
        public ActionResult Index()
        {
            List<Employee> employees = (from emps in client.GetAllEmployees()
                                        select new Employee
                                        {
                                            EmployeeID = emps.EmployeeID,
                                            EmployeeFirstName = emps.EmployeeFirstName,
                                            EmployeeLastName = emps.EmployeeLastName,
                                            DepartmentID = emps.DepartmentID
                                        }).ToList();

            return View(employees);
        }
                
        [HttpPost]
        public ActionResult Index(int EmployeeId)
        {
            var employee = client.GetEmployeeByID(EmployeeId);
            List<Employee> employees = null;

            if (employee != null)
            {
                employees = new List<Employee>()
                {
                    new Employee
                    {
                        EmployeeID = employee.EmployeeID,
                        EmployeeFirstName = employee.EmployeeFirstName,
                        EmployeeLastName = employee.EmployeeLastName,
                        DepartmentID = employee.DepartmentID
                    }
                };
            }
            return View(employees);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeService.EmployeeDTO employeeDTO = new EmployeeService.EmployeeDTO()
                {
                    EmployeeID = employee.EmployeeID,
                    EmployeeFirstName = employee.EmployeeFirstName,
                    EmployeeLastName = employee.EmployeeLastName,
                    DepartmentID = employee.DepartmentID
                };
                if (client.AddEmployee(employeeDTO) > 0)
                {
                    ViewBag.Result = "Employee Added Successfully";
                    return View(employee);
                }
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult Edit(int EmployeeId)
        {
            var searchedEmp = client.GetEmployeeByID(EmployeeId);
            Employee employee = null;

            if (searchedEmp != null)
            {
                employee = new Employee()
                {
                        EmployeeID = searchedEmp.EmployeeID,
                        EmployeeFirstName = searchedEmp.EmployeeFirstName,
                        EmployeeLastName = searchedEmp.EmployeeLastName,
                        DepartmentID = searchedEmp.DepartmentID                    
                };
            }
            return View(employee);            
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeService.EmployeeDTO employeeDTO = new EmployeeService.EmployeeDTO()
                {
                    EmployeeID = employee.EmployeeID,
                    EmployeeFirstName = employee.EmployeeFirstName,
                    EmployeeLastName = employee.EmployeeLastName,
                    DepartmentID = employee.DepartmentID
                };
                if (client.UpdateEmployee(employeeDTO) > 0)
                {
                    ViewBag.Result = "Employee Updated Successfully";
                    return View(employee);
                }
            }
            return View(employee);
        }

        public ActionResult Delete(int EmployeeId)
        {
            if (client.DeleteEmployee(EmployeeId) > 0)
            {
                ViewBag.Result = "Employee data Deleted Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}