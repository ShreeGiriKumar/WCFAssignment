using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LabEmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {

        [OperationContract]
        List<EmployeeDTO> GetAllEmployees();
        [OperationContract]
        EmployeeDTO GetEmployeeByID(int empId);
        [OperationContract]
        int AddEmployee(EmployeeDTO emplopyee);
        [OperationContract]
        int UpdateEmployee(EmployeeDTO emplopyee);
        [OperationContract]
        int DeleteEmployee(int empId);
    }

    [DataContract]
    public class EmployeeDTO
    {
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string EmployeeFirstName { get; set; }
        [DataMember]
        public string EmployeeLastName { get; set; }
        [DataMember]
        public string DepartmentID { get; set; }
    }
}
