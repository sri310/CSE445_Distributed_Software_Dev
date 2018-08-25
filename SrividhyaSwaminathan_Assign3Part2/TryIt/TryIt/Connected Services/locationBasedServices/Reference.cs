﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TryIt.locationBasedServices {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="locationBasedServices.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/weatherService", ReplyAction="http://tempuri.org/IService1/weatherServiceResponse")]
        string[][] weatherService(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/weatherService", ReplyAction="http://tempuri.org/IService1/weatherServiceResponse")]
        System.Threading.Tasks.Task<string[][]> weatherServiceAsync(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/airQuality", ReplyAction="http://tempuri.org/IService1/airQualityResponse")]
        string airQuality(decimal lattitude, decimal longitude);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/airQuality", ReplyAction="http://tempuri.org/IService1/airQualityResponse")]
        System.Threading.Tasks.Task<string> airQualityAsync(decimal lattitude, decimal longitude);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getLatLng", ReplyAction="http://tempuri.org/IService1/getLatLngResponse")]
        string getLatLng(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getLatLng", ReplyAction="http://tempuri.org/IService1/getLatLngResponse")]
        System.Threading.Tasks.Task<string> getLatLngAsync(string zipcode);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : TryIt.locationBasedServices.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<TryIt.locationBasedServices.IService1>, TryIt.locationBasedServices.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[][] weatherService(string zipcode) {
            return base.Channel.weatherService(zipcode);
        }
        
        public System.Threading.Tasks.Task<string[][]> weatherServiceAsync(string zipcode) {
            return base.Channel.weatherServiceAsync(zipcode);
        }
        
        public string airQuality(decimal lattitude, decimal longitude) {
            return base.Channel.airQuality(lattitude, longitude);
        }
        
        public System.Threading.Tasks.Task<string> airQualityAsync(decimal lattitude, decimal longitude) {
            return base.Channel.airQualityAsync(lattitude, longitude);
        }
        
        public string getLatLng(string zipcode) {
            return base.Channel.getLatLng(zipcode);
        }
        
        public System.Threading.Tasks.Task<string> getLatLngAsync(string zipcode) {
            return base.Channel.getLatLngAsync(zipcode);
        }
    }
}
