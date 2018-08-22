using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LabEmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        DatabaseHelper dbHelper = new DatabaseHelper();

        public int AddEmployee(EmployeeDTO emplopyee)
        {            
            return dbHelper.AddEmployee(emplopyee);
        }

        public int DeleteEmployee(int empId)
        {
            return dbHelper.DeleteEmployee(empId);
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            return dbHelper.GetAllEmployees();
        }

        public EmployeeDTO GetEmployeeByID(int empId)
        {         
            return dbHelper.GetEmployeeById(empId);
        }

        public int UpdateEmployee(EmployeeDTO emplopyee)
        {
            return dbHelper.UpdateEmployee(emplopyee);
        }
    }
}
