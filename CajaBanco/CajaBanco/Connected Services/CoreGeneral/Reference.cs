﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CajaBanco.CoreGeneral {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CoreGeneral.GeneralSoap")]
    public interface GeneralSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectTable", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable SelectTable(string tableName, string orderByColumn, string apiKey);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SelectTable", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> SelectTableAsync(string tableName, string orderByColumn, string apiKey);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Cloner", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Cloner(string GUID, string tableName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Cloner", ReplyAction="*")]
        System.Threading.Tasks.Task<string> ClonerAsync(string GUID, string tableName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GeneralSoapChannel : CajaBanco.CoreGeneral.GeneralSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GeneralSoapClient : System.ServiceModel.ClientBase<CajaBanco.CoreGeneral.GeneralSoap>, CajaBanco.CoreGeneral.GeneralSoap {
        
        public GeneralSoapClient() {
        }
        
        public GeneralSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GeneralSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GeneralSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GeneralSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataTable SelectTable(string tableName, string orderByColumn, string apiKey) {
            return base.Channel.SelectTable(tableName, orderByColumn, apiKey);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> SelectTableAsync(string tableName, string orderByColumn, string apiKey) {
            return base.Channel.SelectTableAsync(tableName, orderByColumn, apiKey);
        }
        
        public string Cloner(string GUID, string tableName) {
            return base.Channel.Cloner(GUID, tableName);
        }
        
        public System.Threading.Tasks.Task<string> ClonerAsync(string GUID, string tableName) {
            return base.Channel.ClonerAsync(GUID, tableName);
        }
    }
}
