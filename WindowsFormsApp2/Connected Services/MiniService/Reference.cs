﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp2.MiniService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/ServiceWcf")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
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
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UCLEnum", Namespace="http://schemas.datacontract.org/2004/07/ServiceCommon.Enum")]
    public enum UCLEnum : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Import = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Upload = 20,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MiniService.IServiceWcfService")]
    public interface IServiceWcfService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/GetData", ReplyAction="http://tempuri.org/IServiceWcfService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/GetData", ReplyAction="http://tempuri.org/IServiceWcfService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IServiceWcfService/GetDataUsingDataContractResponse")]
        WindowsFormsApp2.MiniService.CompositeType GetDataUsingDataContract(WindowsFormsApp2.MiniService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IServiceWcfService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<WindowsFormsApp2.MiniService.CompositeType> GetDataUsingDataContractAsync(WindowsFormsApp2.MiniService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/fnH2000ToCDSystem", ReplyAction="http://tempuri.org/IServiceWcfService/fnH2000ToCDSystemResponse")]
        WindowsFormsApp2.MiniService.fnH2000ToCDSystemResponse fnH2000ToCDSystem(WindowsFormsApp2.MiniService.fnH2000ToCDSystemRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/fnH2000ToCDSystem", ReplyAction="http://tempuri.org/IServiceWcfService/fnH2000ToCDSystemResponse")]
        System.Threading.Tasks.Task<WindowsFormsApp2.MiniService.fnH2000ToCDSystemResponse> fnH2000ToCDSystemAsync(WindowsFormsApp2.MiniService.fnH2000ToCDSystemRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/ImportRequest", ReplyAction="http://tempuri.org/IServiceWcfService/ImportRequestResponse")]
        string[] ImportRequest(string customerCd, string ids, bool isSingle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/ImportRequest", ReplyAction="http://tempuri.org/IServiceWcfService/ImportRequestResponse")]
        System.Threading.Tasks.Task<string[]> ImportRequestAsync(string customerCd, string ids, bool isSingle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/exportDF", ReplyAction="http://tempuri.org/IServiceWcfService/exportDFResponse")]
        bool exportDF(string sJson, string Syscustomer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/exportDF", ReplyAction="http://tempuri.org/IServiceWcfService/exportDFResponse")]
        System.Threading.Tasks.Task<bool> exportDFAsync(string sJson, string Syscustomer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/getuploadFile", ReplyAction="http://tempuri.org/IServiceWcfService/getuploadFileResponse")]
        string getuploadFile(string Number, string SysCd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/getuploadFile", ReplyAction="http://tempuri.org/IServiceWcfService/getuploadFileResponse")]
        System.Threading.Tasks.Task<string> getuploadFileAsync(string Number, string SysCd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/SaveUclLog", ReplyAction="http://tempuri.org/IServiceWcfService/SaveUclLogResponse")]
        void SaveUclLog(string EdiNo, WindowsFormsApp2.MiniService.UCLEnum enumtype, string ep, string customercd, string ex, bool status, string UclOperator);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/SaveUclLog", ReplyAction="http://tempuri.org/IServiceWcfService/SaveUclLogResponse")]
        System.Threading.Tasks.Task SaveUclLogAsync(string EdiNo, WindowsFormsApp2.MiniService.UCLEnum enumtype, string ep, string customercd, string ex, bool status, string UclOperator);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/exportEntryList", ReplyAction="http://tempuri.org/IServiceWcfService/exportEntryListResponse")]
        bool exportEntryList(string sJson);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/exportEntryList", ReplyAction="http://tempuri.org/IServiceWcfService/exportEntryListResponse")]
        System.Threading.Tasks.Task<bool> exportEntryListAsync(string sJson);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/importManual", ReplyAction="http://tempuri.org/IServiceWcfService/importManualResponse")]
        bool importManual(string tableName, string Json, string customercd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/importManual", ReplyAction="http://tempuri.org/IServiceWcfService/importManualResponse")]
        System.Threading.Tasks.Task<bool> importManualAsync(string tableName, string Json, string customercd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/H2000ImportDeclare", ReplyAction="http://tempuri.org/IServiceWcfService/H2000ImportDeclareResponse")]
        string[] H2000ImportDeclare(string sJson, string customercd, int days, string date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/H2000ImportDeclare", ReplyAction="http://tempuri.org/IServiceWcfService/H2000ImportDeclareResponse")]
        System.Threading.Tasks.Task<string[]> H2000ImportDeclareAsync(string sJson, string customercd, int days, string date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/importManualSingle", ReplyAction="http://tempuri.org/IServiceWcfService/importManualSingleResponse")]
        string importManualSingle(string json, string customercd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/importManualSingle", ReplyAction="http://tempuri.org/IServiceWcfService/importManualSingleResponse")]
        System.Threading.Tasks.Task<string> importManualSingleAsync(string json, string customercd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/getStatus", ReplyAction="http://tempuri.org/IServiceWcfService/getStatusResponse")]
        void getStatus(string json, string customercd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/getStatus", ReplyAction="http://tempuri.org/IServiceWcfService/getStatusResponse")]
        System.Threading.Tasks.Task getStatusAsync(string json, string customercd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/updateEntryId", ReplyAction="http://tempuri.org/IServiceWcfService/updateEntryIdResponse")]
        void updateEntryId(string[] strList, string customercd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/updateEntryId", ReplyAction="http://tempuri.org/IServiceWcfService/updateEntryIdResponse")]
        System.Threading.Tasks.Task updateEntryIdAsync(string[] strList, string customercd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/updateHeadDtl", ReplyAction="http://tempuri.org/IServiceWcfService/updateHeadDtlResponse")]
        bool updateHeadDtl(string id, string type, long DEH_ID, string Deh_Trade_Name, string Deh_Owner_Name, string Deh_Agent_Name, string Deh_Note_s, long Ded_Id, string Ded_g_Name, string Ded_g_Model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/updateHeadDtl", ReplyAction="http://tempuri.org/IServiceWcfService/updateHeadDtlResponse")]
        System.Threading.Tasks.Task<bool> updateHeadDtlAsync(string id, string type, long DEH_ID, string Deh_Trade_Name, string Deh_Owner_Name, string Deh_Agent_Name, string Deh_Note_s, long Ded_Id, string Ded_g_Name, string Ded_g_Model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/testUi", ReplyAction="http://tempuri.org/IServiceWcfService/testUiResponse")]
        string testUi();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWcfService/testUi", ReplyAction="http://tempuri.org/IServiceWcfService/testUiResponse")]
        System.Threading.Tasks.Task<string> testUiAsync();
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="fnH2000ToCDSystem", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class fnH2000ToCDSystemRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string sJson;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string customercd;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string errorstr;
        
        public fnH2000ToCDSystemRequest() {
        }
        
        public fnH2000ToCDSystemRequest(string sJson, string customercd, string errorstr) {
            this.sJson = sJson;
            this.customercd = customercd;
            this.errorstr = errorstr;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="fnH2000ToCDSystemResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class fnH2000ToCDSystemResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool fnH2000ToCDSystemResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string errorstr;
        
        public fnH2000ToCDSystemResponse() {
        }
        
        public fnH2000ToCDSystemResponse(bool fnH2000ToCDSystemResult, string errorstr) {
            this.fnH2000ToCDSystemResult = fnH2000ToCDSystemResult;
            this.errorstr = errorstr;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceWcfServiceChannel : WindowsFormsApp2.MiniService.IServiceWcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceWcfServiceClient : System.ServiceModel.ClientBase<WindowsFormsApp2.MiniService.IServiceWcfService>, WindowsFormsApp2.MiniService.IServiceWcfService {
        
        public ServiceWcfServiceClient() {
        }
        
        public ServiceWcfServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceWcfServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceWcfServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceWcfServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public WindowsFormsApp2.MiniService.CompositeType GetDataUsingDataContract(WindowsFormsApp2.MiniService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<WindowsFormsApp2.MiniService.CompositeType> GetDataUsingDataContractAsync(WindowsFormsApp2.MiniService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WindowsFormsApp2.MiniService.fnH2000ToCDSystemResponse WindowsFormsApp2.MiniService.IServiceWcfService.fnH2000ToCDSystem(WindowsFormsApp2.MiniService.fnH2000ToCDSystemRequest request) {
            return base.Channel.fnH2000ToCDSystem(request);
        }
        
        public bool fnH2000ToCDSystem(string sJson, string customercd, ref string errorstr) {
            WindowsFormsApp2.MiniService.fnH2000ToCDSystemRequest inValue = new WindowsFormsApp2.MiniService.fnH2000ToCDSystemRequest();
            inValue.sJson = sJson;
            inValue.customercd = customercd;
            inValue.errorstr = errorstr;
            WindowsFormsApp2.MiniService.fnH2000ToCDSystemResponse retVal = ((WindowsFormsApp2.MiniService.IServiceWcfService)(this)).fnH2000ToCDSystem(inValue);
            errorstr = retVal.errorstr;
            return retVal.fnH2000ToCDSystemResult;
        }
        
        public System.Threading.Tasks.Task<WindowsFormsApp2.MiniService.fnH2000ToCDSystemResponse> fnH2000ToCDSystemAsync(WindowsFormsApp2.MiniService.fnH2000ToCDSystemRequest request) {
            return base.Channel.fnH2000ToCDSystemAsync(request);
        }
        
        public string[] ImportRequest(string customerCd, string ids, bool isSingle) {
            return base.Channel.ImportRequest(customerCd, ids, isSingle);
        }
        
        public System.Threading.Tasks.Task<string[]> ImportRequestAsync(string customerCd, string ids, bool isSingle) {
            return base.Channel.ImportRequestAsync(customerCd, ids, isSingle);
        }
        
        public bool exportDF(string sJson, string Syscustomer) {
            return base.Channel.exportDF(sJson, Syscustomer);
        }
        
        public System.Threading.Tasks.Task<bool> exportDFAsync(string sJson, string Syscustomer) {
            return base.Channel.exportDFAsync(sJson, Syscustomer);
        }
        
        public string getuploadFile(string Number, string SysCd) {
            return base.Channel.getuploadFile(Number, SysCd);
        }
        
        public System.Threading.Tasks.Task<string> getuploadFileAsync(string Number, string SysCd) {
            return base.Channel.getuploadFileAsync(Number, SysCd);
        }
        
        public void SaveUclLog(string EdiNo, WindowsFormsApp2.MiniService.UCLEnum enumtype, string ep, string customercd, string ex, bool status, string UclOperator) {
            base.Channel.SaveUclLog(EdiNo, enumtype, ep, customercd, ex, status, UclOperator);
        }
        
        public System.Threading.Tasks.Task SaveUclLogAsync(string EdiNo, WindowsFormsApp2.MiniService.UCLEnum enumtype, string ep, string customercd, string ex, bool status, string UclOperator) {
            return base.Channel.SaveUclLogAsync(EdiNo, enumtype, ep, customercd, ex, status, UclOperator);
        }
        
        public bool exportEntryList(string sJson) {
            return base.Channel.exportEntryList(sJson);
        }
        
        public System.Threading.Tasks.Task<bool> exportEntryListAsync(string sJson) {
            return base.Channel.exportEntryListAsync(sJson);
        }
        
        public bool importManual(string tableName, string Json, string customercd) {
            return base.Channel.importManual(tableName, Json, customercd);
        }
        
        public System.Threading.Tasks.Task<bool> importManualAsync(string tableName, string Json, string customercd) {
            return base.Channel.importManualAsync(tableName, Json, customercd);
        }
        
        public string[] H2000ImportDeclare(string sJson, string customercd, int days, string date) {
            return base.Channel.H2000ImportDeclare(sJson, customercd, days, date);
        }
        
        public System.Threading.Tasks.Task<string[]> H2000ImportDeclareAsync(string sJson, string customercd, int days, string date) {
            return base.Channel.H2000ImportDeclareAsync(sJson, customercd, days, date);
        }
        
        public string importManualSingle(string json, string customercd) {
            return base.Channel.importManualSingle(json, customercd);
        }
        
        public System.Threading.Tasks.Task<string> importManualSingleAsync(string json, string customercd) {
            return base.Channel.importManualSingleAsync(json, customercd);
        }
        
        public void getStatus(string json, string customercd) {
            base.Channel.getStatus(json, customercd);
        }
        
        public System.Threading.Tasks.Task getStatusAsync(string json, string customercd) {
            return base.Channel.getStatusAsync(json, customercd);
        }
        
        public void updateEntryId(string[] strList, string customercd) {
            base.Channel.updateEntryId(strList, customercd);
        }
        
        public System.Threading.Tasks.Task updateEntryIdAsync(string[] strList, string customercd) {
            return base.Channel.updateEntryIdAsync(strList, customercd);
        }
        
        public bool updateHeadDtl(string id, string type, long DEH_ID, string Deh_Trade_Name, string Deh_Owner_Name, string Deh_Agent_Name, string Deh_Note_s, long Ded_Id, string Ded_g_Name, string Ded_g_Model) {
            return base.Channel.updateHeadDtl(id, type, DEH_ID, Deh_Trade_Name, Deh_Owner_Name, Deh_Agent_Name, Deh_Note_s, Ded_Id, Ded_g_Name, Ded_g_Model);
        }
        
        public System.Threading.Tasks.Task<bool> updateHeadDtlAsync(string id, string type, long DEH_ID, string Deh_Trade_Name, string Deh_Owner_Name, string Deh_Agent_Name, string Deh_Note_s, long Ded_Id, string Ded_g_Name, string Ded_g_Model) {
            return base.Channel.updateHeadDtlAsync(id, type, DEH_ID, Deh_Trade_Name, Deh_Owner_Name, Deh_Agent_Name, Deh_Note_s, Ded_Id, Ded_g_Name, Ded_g_Model);
        }
        
        public string testUi() {
            return base.Channel.testUi();
        }
        
        public System.Threading.Tasks.Task<string> testUiAsync() {
            return base.Channel.testUiAsync();
        }
    }
}
