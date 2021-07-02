﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace DanceProject.localhost {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WebService1Soap", Namespace="http://tempuri.org/")]
    public partial class WebService1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetTblByQueryOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddPerformanceOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteDateOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddPerformanceDateOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeletePerformanceOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateLengthOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WebService1() {
            this.Url = global::DanceProject.Properties.Settings.Default.DanceProject_localhost_WebService1;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetTblByQueryCompletedEventHandler GetTblByQueryCompleted;
        
        /// <remarks/>
        public event AddPerformanceCompletedEventHandler AddPerformanceCompleted;
        
        /// <remarks/>
        public event DeleteDateCompletedEventHandler DeleteDateCompleted;
        
        /// <remarks/>
        public event AddPerformanceDateCompletedEventHandler AddPerformanceDateCompleted;
        
        /// <remarks/>
        public event DeletePerformanceCompletedEventHandler DeletePerformanceCompleted;
        
        /// <remarks/>
        public event UpdateCompletedEventHandler UpdateCompleted;
        
        /// <remarks/>
        public event UpdateLengthCompletedEventHandler UpdateLengthCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetTblByQuery", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetTblByQuery(string query) {
            object[] results = this.Invoke("GetTblByQuery", new object[] {
                        query});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void GetTblByQueryAsync(string query) {
            this.GetTblByQueryAsync(query, null);
        }
        
        /// <remarks/>
        public void GetTblByQueryAsync(string query, object userState) {
            if ((this.GetTblByQueryOperationCompleted == null)) {
                this.GetTblByQueryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetTblByQueryOperationCompleted);
            }
            this.InvokeAsync("GetTblByQuery", new object[] {
                        query}, this.GetTblByQueryOperationCompleted, userState);
        }
        
        private void OnGetTblByQueryOperationCompleted(object arg) {
            if ((this.GetTblByQueryCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetTblByQueryCompleted(this, new GetTblByQueryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddPerformance", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AddPerformance(string PerformanceName, string PerformancePhoto, string ChoreographerId) {
            this.Invoke("AddPerformance", new object[] {
                        PerformanceName,
                        PerformancePhoto,
                        ChoreographerId});
        }
        
        /// <remarks/>
        public void AddPerformanceAsync(string PerformanceName, string PerformancePhoto, string ChoreographerId) {
            this.AddPerformanceAsync(PerformanceName, PerformancePhoto, ChoreographerId, null);
        }
        
        /// <remarks/>
        public void AddPerformanceAsync(string PerformanceName, string PerformancePhoto, string ChoreographerId, object userState) {
            if ((this.AddPerformanceOperationCompleted == null)) {
                this.AddPerformanceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddPerformanceOperationCompleted);
            }
            this.InvokeAsync("AddPerformance", new object[] {
                        PerformanceName,
                        PerformancePhoto,
                        ChoreographerId}, this.AddPerformanceOperationCompleted, userState);
        }
        
        private void OnAddPerformanceOperationCompleted(object arg) {
            if ((this.AddPerformanceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddPerformanceCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/DeleteDate", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DeleteDate(string PerformanceId, string PerformanceDate, string PerformanceHour) {
            this.Invoke("DeleteDate", new object[] {
                        PerformanceId,
                        PerformanceDate,
                        PerformanceHour});
        }
        
        /// <remarks/>
        public void DeleteDateAsync(string PerformanceId, string PerformanceDate, string PerformanceHour) {
            this.DeleteDateAsync(PerformanceId, PerformanceDate, PerformanceHour, null);
        }
        
        /// <remarks/>
        public void DeleteDateAsync(string PerformanceId, string PerformanceDate, string PerformanceHour, object userState) {
            if ((this.DeleteDateOperationCompleted == null)) {
                this.DeleteDateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteDateOperationCompleted);
            }
            this.InvokeAsync("DeleteDate", new object[] {
                        PerformanceId,
                        PerformanceDate,
                        PerformanceHour}, this.DeleteDateOperationCompleted, userState);
        }
        
        private void OnDeleteDateOperationCompleted(object arg) {
            if ((this.DeleteDateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteDateCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddPerformanceDate", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AddPerformanceDate(string PerformanceId, string PerformanceDate, string PerformanceHour, string PerformancePlace) {
            this.Invoke("AddPerformanceDate", new object[] {
                        PerformanceId,
                        PerformanceDate,
                        PerformanceHour,
                        PerformancePlace});
        }
        
        /// <remarks/>
        public void AddPerformanceDateAsync(string PerformanceId, string PerformanceDate, string PerformanceHour, string PerformancePlace) {
            this.AddPerformanceDateAsync(PerformanceId, PerformanceDate, PerformanceHour, PerformancePlace, null);
        }
        
        /// <remarks/>
        public void AddPerformanceDateAsync(string PerformanceId, string PerformanceDate, string PerformanceHour, string PerformancePlace, object userState) {
            if ((this.AddPerformanceDateOperationCompleted == null)) {
                this.AddPerformanceDateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddPerformanceDateOperationCompleted);
            }
            this.InvokeAsync("AddPerformanceDate", new object[] {
                        PerformanceId,
                        PerformanceDate,
                        PerformanceHour,
                        PerformancePlace}, this.AddPerformanceDateOperationCompleted, userState);
        }
        
        private void OnAddPerformanceDateOperationCompleted(object arg) {
            if ((this.AddPerformanceDateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddPerformanceDateCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/DeletePerformance", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DeletePerformance(string PerformanceId) {
            this.Invoke("DeletePerformance", new object[] {
                        PerformanceId});
        }
        
        /// <remarks/>
        public void DeletePerformanceAsync(string PerformanceId) {
            this.DeletePerformanceAsync(PerformanceId, null);
        }
        
        /// <remarks/>
        public void DeletePerformanceAsync(string PerformanceId, object userState) {
            if ((this.DeletePerformanceOperationCompleted == null)) {
                this.DeletePerformanceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeletePerformanceOperationCompleted);
            }
            this.InvokeAsync("DeletePerformance", new object[] {
                        PerformanceId}, this.DeletePerformanceOperationCompleted, userState);
        }
        
        private void OnDeletePerformanceOperationCompleted(object arg) {
            if ((this.DeletePerformanceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeletePerformanceCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Update", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Update(string PerformanceId, string PerformanceName, string PerformancePhoto) {
            this.Invoke("Update", new object[] {
                        PerformanceId,
                        PerformanceName,
                        PerformancePhoto});
        }
        
        /// <remarks/>
        public void UpdateAsync(string PerformanceId, string PerformanceName, string PerformancePhoto) {
            this.UpdateAsync(PerformanceId, PerformanceName, PerformancePhoto, null);
        }
        
        /// <remarks/>
        public void UpdateAsync(string PerformanceId, string PerformanceName, string PerformancePhoto, object userState) {
            if ((this.UpdateOperationCompleted == null)) {
                this.UpdateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateOperationCompleted);
            }
            this.InvokeAsync("Update", new object[] {
                        PerformanceId,
                        PerformanceName,
                        PerformancePhoto}, this.UpdateOperationCompleted, userState);
        }
        
        private void OnUpdateOperationCompleted(object arg) {
            if ((this.UpdateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UpdateLength", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void UpdateLength(string PerformanceId, decimal PerformanceLength) {
            this.Invoke("UpdateLength", new object[] {
                        PerformanceId,
                        PerformanceLength});
        }
        
        /// <remarks/>
        public void UpdateLengthAsync(string PerformanceId, decimal PerformanceLength) {
            this.UpdateLengthAsync(PerformanceId, PerformanceLength, null);
        }
        
        /// <remarks/>
        public void UpdateLengthAsync(string PerformanceId, decimal PerformanceLength, object userState) {
            if ((this.UpdateLengthOperationCompleted == null)) {
                this.UpdateLengthOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateLengthOperationCompleted);
            }
            this.InvokeAsync("UpdateLength", new object[] {
                        PerformanceId,
                        PerformanceLength}, this.UpdateLengthOperationCompleted, userState);
        }
        
        private void OnUpdateLengthOperationCompleted(object arg) {
            if ((this.UpdateLengthCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateLengthCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void GetTblByQueryCompletedEventHandler(object sender, GetTblByQueryCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetTblByQueryCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetTblByQueryCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void AddPerformanceCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void DeleteDateCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void AddPerformanceDateCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void DeletePerformanceCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void UpdateCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void UpdateLengthCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591