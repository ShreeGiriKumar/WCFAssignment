using AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoNet.Controllers
{
    public class GreetingServiceController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            //JobService.GreetingServiceClient client = new JobService.GreetingServiceClient("WSHttpBinding_IGreetingService");
            //List <JobOpening> opening = (from m in client.GetAllJobOpenings()
            //                      select new JobOpening
            //                      {
            //                          JobCode = m.JobCode,
            //                          JobDescription = m.JobDescription,
            //                          JobRole = m.JobRole
            //                      }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection col)
        {
            //JobService.GreetingServiceClient client = new JobService.GreetingServiceClient("WSHttpBinding_IGreetingService");
            //List<JobOpening> opening = (from m in client.GetJobOpeningsByRole(col["role"])
            //                            select new JobOpening
            //                            {
            //                                JobCode = m.JobCode,
            //                                JobDescription = m.JobDescription,
            //                                JobRole = m.JobRole
            //                            }).ToList();
            return View();
        }

        [HttpGet]
        public ActionResult Calculator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculator(FormCollection col)
        {
            //JobService.GreetingServiceClient client = new JobService.GreetingServiceClient("WSHttpBinding_IGreetingService");
            //ViewBag.Add = client.AddNumber(Convert.ToInt32(col["num1"]), Convert.ToInt32(col["num2"]));
            //ViewBag.Sub = client.SubtractNumber(Convert.ToInt32(col["num1"]), Convert.ToInt32(col["num2"]));
            //ViewBag.Mul = client.MultiplyNumber(Convert.ToInt32(col["num1"]), Convert.ToInt32(col["num2"]));
            //ViewBag.Div = client.DivideNumber(Convert.ToInt32(col["num1"]), Convert.ToInt32(col["num2"]));
            return View();
        }
    }
}