﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Softtek.Academy2018.Demo.Console.UserManagementService_Ref {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseRequest", Namespace="http://schemas.datacontract.org/2004/07/Softtek.Academy2018.Demo.WCF.Messages")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.GetUserRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.DeleteUserRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.UpdateUserRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.CreateUserRequest))]
    public partial class BaseRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetUserRequest", Namespace="http://schemas.datacontract.org/2004/07/Softtek.Academy2018.Demo.WCF.Messages")]
    [System.SerializableAttribute()]
    public partial class GetUserRequest : Softtek.Academy2018.Demo.Console.UserManagementService_Ref.BaseRequest {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DeleteUserRequest", Namespace="http://schemas.datacontract.org/2004/07/Softtek.Academy2018.Demo.WCF.Messages")]
    [System.SerializableAttribute()]
    public partial class DeleteUserRequest : Softtek.Academy2018.Demo.Console.UserManagementService_Ref.BaseRequest {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UpdateUserRequest", Namespace="http://schemas.datacontract.org/2004/07/Softtek.Academy2018.Demo.WCF.Messages")]
    [System.SerializableAttribute()]
    public partial class UpdateUserRequest : Softtek.Academy2018.Demo.Console.UserManagementService_Ref.BaseRequest {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DateOfBirthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ISField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double SalaryField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DateOfBirth {
            get {
                return this.DateOfBirthField;
            }
            set {
                if ((this.DateOfBirthField.Equals(value) != true)) {
                    this.DateOfBirthField = value;
                    this.RaisePropertyChanged("DateOfBirth");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IS {
            get {
                return this.ISField;
            }
            set {
                if ((object.ReferenceEquals(this.ISField, value) != true)) {
                    this.ISField = value;
                    this.RaisePropertyChanged("IS");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Salary {
            get {
                return this.SalaryField;
            }
            set {
                if ((this.SalaryField.Equals(value) != true)) {
                    this.SalaryField = value;
                    this.RaisePropertyChanged("Salary");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CreateUserRequest", Namespace="http://schemas.datacontract.org/2004/07/Softtek.Academy2018.Demo.WCF.Messages")]
    [System.SerializableAttribute()]
    public partial class CreateUserRequest : Softtek.Academy2018.Demo.Console.UserManagementService_Ref.BaseRequest {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DateOfBirthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ISField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double SalaryField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DateOfBirth {
            get {
                return this.DateOfBirthField;
            }
            set {
                if ((this.DateOfBirthField.Equals(value) != true)) {
                    this.DateOfBirthField = value;
                    this.RaisePropertyChanged("DateOfBirth");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IS {
            get {
                return this.ISField;
            }
            set {
                if ((object.ReferenceEquals(this.ISField, value) != true)) {
                    this.ISField = value;
                    this.RaisePropertyChanged("IS");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Salary {
            get {
                return this.SalaryField;
            }
            set {
                if ((this.SalaryField.Equals(value) != true)) {
                    this.SalaryField = value;
                    this.RaisePropertyChanged("Salary");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseResponse", Namespace="http://schemas.datacontract.org/2004/07/Softtek.Academy2018.Demo.WCF.Messages")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.GetUserResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.DeleteUserResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.UpdateUserResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.CreateUserResponse))]
    public partial class BaseResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool SuccessField;
        
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
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Success {
            get {
                return this.SuccessField;
            }
            set {
                if ((this.SuccessField.Equals(value) != true)) {
                    this.SuccessField = value;
                    this.RaisePropertyChanged("Success");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetUserResponse", Namespace="http://schemas.datacontract.org/2004/07/Softtek.Academy2018.Demo.WCF.Messages")]
    [System.SerializableAttribute()]
    public partial class GetUserResponse : Softtek.Academy2018.Demo.Console.UserManagementService_Ref.BaseResponse {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreatedDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DateOfBirthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ISField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> ModifiedDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double SalaryField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CreatedDate {
            get {
                return this.CreatedDateField;
            }
            set {
                if ((this.CreatedDateField.Equals(value) != true)) {
                    this.CreatedDateField = value;
                    this.RaisePropertyChanged("CreatedDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DateOfBirth {
            get {
                return this.DateOfBirthField;
            }
            set {
                if ((this.DateOfBirthField.Equals(value) != true)) {
                    this.DateOfBirthField = value;
                    this.RaisePropertyChanged("DateOfBirth");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IS {
            get {
                return this.ISField;
            }
            set {
                if ((object.ReferenceEquals(this.ISField, value) != true)) {
                    this.ISField = value;
                    this.RaisePropertyChanged("IS");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> ModifiedDate {
            get {
                return this.ModifiedDateField;
            }
            set {
                if ((this.ModifiedDateField.Equals(value) != true)) {
                    this.ModifiedDateField = value;
                    this.RaisePropertyChanged("ModifiedDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Salary {
            get {
                return this.SalaryField;
            }
            set {
                if ((this.SalaryField.Equals(value) != true)) {
                    this.SalaryField = value;
                    this.RaisePropertyChanged("Salary");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DeleteUserResponse", Namespace="http://schemas.datacontract.org/2004/07/Softtek.Academy2018.Demo.WCF.Messages")]
    [System.SerializableAttribute()]
    public partial class DeleteUserResponse : Softtek.Academy2018.Demo.Console.UserManagementService_Ref.BaseResponse {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UpdateUserResponse", Namespace="http://schemas.datacontract.org/2004/07/Softtek.Academy2018.Demo.WCF.Messages")]
    [System.SerializableAttribute()]
    public partial class UpdateUserResponse : Softtek.Academy2018.Demo.Console.UserManagementService_Ref.BaseResponse {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ModifiedDateField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ModifiedDate {
            get {
                return this.ModifiedDateField;
            }
            set {
                if ((this.ModifiedDateField.Equals(value) != true)) {
                    this.ModifiedDateField = value;
                    this.RaisePropertyChanged("ModifiedDate");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CreateUserResponse", Namespace="http://schemas.datacontract.org/2004/07/Softtek.Academy2018.Demo.WCF.Messages")]
    [System.SerializableAttribute()]
    public partial class CreateUserResponse : Softtek.Academy2018.Demo.Console.UserManagementService_Ref.BaseResponse {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserManagementService_Ref.IUserManagementService")]
    public interface IUserManagementService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserManagementService/CreateUser", ReplyAction="http://tempuri.org/IUserManagementService/CreateUserResponse")]
        Softtek.Academy2018.Demo.Console.UserManagementService_Ref.CreateUserResponse CreateUser(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.CreateUserRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserManagementService/CreateUser", ReplyAction="http://tempuri.org/IUserManagementService/CreateUserResponse")]
        System.Threading.Tasks.Task<Softtek.Academy2018.Demo.Console.UserManagementService_Ref.CreateUserResponse> CreateUserAsync(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.CreateUserRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserManagementService/GetUser", ReplyAction="http://tempuri.org/IUserManagementService/GetUserResponse")]
        Softtek.Academy2018.Demo.Console.UserManagementService_Ref.GetUserResponse GetUser(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.GetUserRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserManagementService/GetUser", ReplyAction="http://tempuri.org/IUserManagementService/GetUserResponse")]
        System.Threading.Tasks.Task<Softtek.Academy2018.Demo.Console.UserManagementService_Ref.GetUserResponse> GetUserAsync(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.GetUserRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserManagementService/DeleteUser", ReplyAction="http://tempuri.org/IUserManagementService/DeleteUserResponse")]
        Softtek.Academy2018.Demo.Console.UserManagementService_Ref.DeleteUserResponse DeleteUser(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.DeleteUserRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserManagementService/DeleteUser", ReplyAction="http://tempuri.org/IUserManagementService/DeleteUserResponse")]
        System.Threading.Tasks.Task<Softtek.Academy2018.Demo.Console.UserManagementService_Ref.DeleteUserResponse> DeleteUserAsync(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.DeleteUserRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserManagementService/UpdateUser", ReplyAction="http://tempuri.org/IUserManagementService/UpdateUserResponse")]
        Softtek.Academy2018.Demo.Console.UserManagementService_Ref.UpdateUserResponse UpdateUser(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.UpdateUserRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserManagementService/UpdateUser", ReplyAction="http://tempuri.org/IUserManagementService/UpdateUserResponse")]
        System.Threading.Tasks.Task<Softtek.Academy2018.Demo.Console.UserManagementService_Ref.UpdateUserResponse> UpdateUserAsync(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.UpdateUserRequest request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserManagementServiceChannel : Softtek.Academy2018.Demo.Console.UserManagementService_Ref.IUserManagementService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserManagementServiceClient : System.ServiceModel.ClientBase<Softtek.Academy2018.Demo.Console.UserManagementService_Ref.IUserManagementService>, Softtek.Academy2018.Demo.Console.UserManagementService_Ref.IUserManagementService {
        
        public UserManagementServiceClient() {
        }
        
        public UserManagementServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserManagementServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserManagementServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserManagementServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Softtek.Academy2018.Demo.Console.UserManagementService_Ref.CreateUserResponse CreateUser(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.CreateUserRequest request) {
            return base.Channel.CreateUser(request);
        }
        
        public System.Threading.Tasks.Task<Softtek.Academy2018.Demo.Console.UserManagementService_Ref.CreateUserResponse> CreateUserAsync(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.CreateUserRequest request) {
            return base.Channel.CreateUserAsync(request);
        }
        
        public Softtek.Academy2018.Demo.Console.UserManagementService_Ref.GetUserResponse GetUser(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.GetUserRequest request) {
            return base.Channel.GetUser(request);
        }
        
        public System.Threading.Tasks.Task<Softtek.Academy2018.Demo.Console.UserManagementService_Ref.GetUserResponse> GetUserAsync(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.GetUserRequest request) {
            return base.Channel.GetUserAsync(request);
        }
        
        public Softtek.Academy2018.Demo.Console.UserManagementService_Ref.DeleteUserResponse DeleteUser(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.DeleteUserRequest request) {
            return base.Channel.DeleteUser(request);
        }
        
        public System.Threading.Tasks.Task<Softtek.Academy2018.Demo.Console.UserManagementService_Ref.DeleteUserResponse> DeleteUserAsync(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.DeleteUserRequest request) {
            return base.Channel.DeleteUserAsync(request);
        }
        
        public Softtek.Academy2018.Demo.Console.UserManagementService_Ref.UpdateUserResponse UpdateUser(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.UpdateUserRequest request) {
            return base.Channel.UpdateUser(request);
        }
        
        public System.Threading.Tasks.Task<Softtek.Academy2018.Demo.Console.UserManagementService_Ref.UpdateUserResponse> UpdateUserAsync(Softtek.Academy2018.Demo.Console.UserManagementService_Ref.UpdateUserRequest request) {
            return base.Channel.UpdateUserAsync(request);
        }
    }
}
