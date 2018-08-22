using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ServiceHoster
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost svcHost = null;
            try
            {
                svcHost = new ServiceHost(typeof(LabEmployeeService.EmployeeService));
                svcHost.Open(); Console.WriteLine("\n\nService is Running  at following address");
                Console.WriteLine("\nhttp://localhost:5000/EmployeeService.svc");                
            }
            catch (Exception eX)
            {
                svcHost = null;
                Console.WriteLine("Service can not be started \n\nError Message [" + eX.Message + "]");
            }
            if (svcHost != null)
            {
                Console.WriteLine("\nPress any key to close the Service");
                Console.ReadKey();
                svcHost.Close();
                svcHost = null;
            }
            Console.ReadKey();
        }
    }
}
