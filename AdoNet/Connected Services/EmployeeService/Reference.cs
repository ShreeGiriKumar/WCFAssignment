﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdoNet.EmployeeService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EmployeeDTO", Namespace="http://schemas.datacontract.org/2004/07/LabEmployeeService")]
    [System.SerializableAttribute()]
    public partial class EmployeeDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartmentIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmployeeFirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EmployeeIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmployeeLastNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DepartmentID {
            get {
                return this.DepartmentIDField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartmentIDField, value) != true)) {
                    this.DepartmentIDField = value;
                    this.RaisePropertyChanged("DepartmentID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EmployeeFirstName {
            get {
                return this.EmployeeFirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.EmployeeFirstNameField, value) != true)) {
                    this.EmployeeFirstNameField = value;
                    this.RaisePropertyChanged("EmployeeFirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EmployeeID {
            get {
                return this.EmployeeIDField;
            }
            set {
                if ((this.EmployeeIDField.Equals(value) != true)) {
                    this.EmployeeIDField = value;
                    this.RaisePropertyChanged("EmployeeID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EmployeeLastName {
            get {
                return this.EmployeeLastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.EmployeeLastNameField, value) != true)) {
                    this.EmployeeLastNameField = value;
                    this.RaisePropertyChanged("EmployeeLastName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeService.IEmployeeService")]
    public interface IEmployeeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetAllEmployees", ReplyAction="http://tempuri.org/IEmployeeService/GetAllEmployeesResponse")]
        AdoNet.EmployeeService.EmployeeDTO[] GetAllEmployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetAllEmployees", ReplyAction="http://tempuri.org/IEmployeeService/GetAllEmployeesResponse")]
        System.Threading.Tasks.Task<AdoNet.EmployeeService.EmployeeDTO[]> GetAllEmployeesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetEmployeeByID", ReplyAction="http://tempuri.org/IEmployeeService/GetEmployeeByIDResponse")]
        AdoNet.EmployeeService.EmployeeDTO GetEmployeeByID(int empId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetEmployeeByID", ReplyAction="http://tempuri.org/IEmployeeService/GetEmployeeByIDResponse")]
        System.Threading.Tasks.Task<AdoNet.EmployeeService.EmployeeDTO> GetEmployeeByIDAsync(int empId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/AddEmployee", ReplyAction="http://tempuri.org/IEmployeeService/AddEmployeeResponse")]
        int AddEmployee(AdoNet.EmployeeService.EmployeeDTO emplopyee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/AddEmployee", ReplyAction="http://tempuri.org/IEmployeeService/AddEmployeeResponse")]
        System.Threading.Tasks.Task<int> AddEmployeeAsync(AdoNet.EmployeeService.EmployeeDTO emplopyee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/UpdateEmployee", ReplyAction="http://tempuri.org/IEmployeeService/UpdateEmployeeResponse")]
        int UpdateEmployee(AdoNet.EmployeeService.EmployeeDTO emplopyee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/UpdateEmployee", ReplyAction="http://tempuri.org/IEmployeeService/UpdateEmployeeResponse")]
        System.Threading.Tasks.Task<int> UpdateEmployeeAsync(AdoNet.EmployeeService.EmployeeDTO emplopyee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/DeleteEmployee", ReplyAction="http://tempuri.org/IEmployeeService/DeleteEmployeeResponse")]
        int DeleteEmployee(int empId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/DeleteEmployee", ReplyAction="http://tempuri.org/IEmployeeService/DeleteEmployeeResponse")]
        System.Threading.Tasks.Task<int> DeleteEmployeeAsync(int empId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmployeeServiceChannel : AdoNet.EmployeeService.IEmployeeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmployeeServiceClient : System.ServiceModel.ClientBase<AdoNet.EmployeeService.IEmployeeService>, AdoNet.EmployeeService.IEmployeeService {
        
        public EmployeeServiceClient() {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AdoNet.EmployeeService.EmployeeDTO[] GetAllEmployees() {
            return base.Channel.GetAllEmployees();
        }
        
        public System.Threading.Tasks.Task<AdoNet.EmployeeService.EmployeeDTO[]> GetAllEmployeesAsync() {
            return base.Channel.GetAllEmployeesAsync();
        }
        
        public AdoNet.EmployeeService.EmployeeDTO GetEmployeeByID(int empId) {
            return base.Channel.GetEmployeeByID(empId);
        }
        
        public System.Threading.Tasks.Task<AdoNet.EmployeeService.EmployeeDTO> GetEmployeeByIDAsync(int empId) {
            return base.Channel.GetEmployeeByIDAsync(empId);
        }
        
        public int AddEmployee(AdoNet.EmployeeService.EmployeeDTO emplopyee) {
            return base.Channel.AddEmployee(emplopyee);
        }
        
        public System.Threading.Tasks.Task<int> AddEmployeeAsync(AdoNet.EmployeeService.EmployeeDTO emplopyee) {
            return base.Channel.AddEmployeeAsync(emplopyee);
        }
        
        public int UpdateEmployee(AdoNet.EmployeeService.EmployeeDTO emplopyee) {
            return base.Channel.UpdateEmployee(emplopyee);
        }
        
        public System.Threading.Tasks.Task<int> UpdateEmployeeAsync(AdoNet.EmployeeService.EmployeeDTO emplopyee) {
            return base.Channel.UpdateEmployeeAsync(emplopyee);
        }
        
        public int DeleteEmployee(int empId) {
            return base.Channel.DeleteEmployee(empId);
        }
        
        public System.Threading.Tasks.Task<int> DeleteEmployeeAsync(int empId) {
            return base.Channel.DeleteEmployeeAsync(empId);
        }
    }
}