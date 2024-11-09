﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Player", Namespace="http://schemas.datacontract.org/2004/07/Service")]
    public partial class Player : object, System.ComponentModel.INotifyPropertyChanged
    {
        
        private ServiceReference.Credentials CredentialsField;
        
        private int CurrentBalanceField;
        
        private ServiceReference.Ticket TicketField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference.Credentials Credentials
        {
            get
            {
                return this.CredentialsField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CredentialsField, value) != true))
                {
                    this.CredentialsField = value;
                    this.RaisePropertyChanged("Credentials");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CurrentBalance
        {
            get
            {
                return this.CurrentBalanceField;
            }
            set
            {
                if ((this.CurrentBalanceField.Equals(value) != true))
                {
                    this.CurrentBalanceField = value;
                    this.RaisePropertyChanged("CurrentBalance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference.Ticket Ticket
        {
            get
            {
                return this.TicketField;
            }
            set
            {
                if ((object.ReferenceEquals(this.TicketField, value) != true))
                {
                    this.TicketField = value;
                    this.RaisePropertyChanged("Ticket");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Credentials", Namespace="http://schemas.datacontract.org/2004/07/Service")]
    public partial class Credentials : object, System.ComponentModel.INotifyPropertyChanged
    {
        
        private string FirstNameField;
        
        private int IdField;
        
        private string LastNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName
        {
            get
            {
                return this.FirstNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true))
                {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                if ((this.IdField.Equals(value) != true))
                {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName
        {
            get
            {
                return this.LastNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LastNameField, value) != true))
                {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Ticket", Namespace="http://schemas.datacontract.org/2004/07/Service")]
    public partial class Ticket : object, System.ComponentModel.INotifyPropertyChanged
    {
        
        private int FirstNumberField;
        
        private int InvestedMoneyField;
        
        private int SecondNumberField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FirstNumber
        {
            get
            {
                return this.FirstNumberField;
            }
            set
            {
                if ((this.FirstNumberField.Equals(value) != true))
                {
                    this.FirstNumberField = value;
                    this.RaisePropertyChanged("FirstNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int InvestedMoney
        {
            get
            {
                return this.InvestedMoneyField;
            }
            set
            {
                if ((this.InvestedMoneyField.Equals(value) != true))
                {
                    this.InvestedMoneyField = value;
                    this.RaisePropertyChanged("InvestedMoney");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SecondNumber
        {
            get
            {
                return this.SecondNumberField;
            }
            set
            {
                if ((this.SecondNumberField.Equals(value) != true))
                {
                    this.SecondNumberField = value;
                    this.RaisePropertyChanged("SecondNumber");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IPublisher")]
    public interface IPublisher
    {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPublisher/Publish")]
        void Publish(int FirstNumber, int SecondNumber);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPublisher/Publish")]
        System.Threading.Tasks.Task PublishAsync(int FirstNumber, int SecondNumber);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IPublisherChannel : ServiceReference.IPublisher, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class PublisherClient : System.ServiceModel.ClientBase<ServiceReference.IPublisher>, ServiceReference.IPublisher
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public PublisherClient() : 
                base(PublisherClient.GetDefaultBinding(), PublisherClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IPublisher.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PublisherClient(EndpointConfiguration endpointConfiguration) : 
                base(PublisherClient.GetBindingForEndpoint(endpointConfiguration), PublisherClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PublisherClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(PublisherClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PublisherClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(PublisherClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PublisherClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public void Publish(int FirstNumber, int SecondNumber)
        {
            base.Channel.Publish(FirstNumber, SecondNumber);
        }
        
        public System.Threading.Tasks.Task PublishAsync(int FirstNumber, int SecondNumber)
        {
            return base.Channel.PublishAsync(FirstNumber, SecondNumber);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IPublisher))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IPublisher))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:55637/Service.svc/pub");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return PublisherClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IPublisher);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return PublisherClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IPublisher);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IPublisher,
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.ISubscriber", CallbackContract=typeof(ServiceReference.ISubscriberCallback))]
    public interface ISubscriber
    {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISubscriber/InitPlayer")]
        void InitPlayer(ServiceReference.Player player);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISubscriber/InitPlayer")]
        System.Threading.Tasks.Task InitPlayerAsync(ServiceReference.Player player);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface ISubscriberCallback
    {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISubscriber/OnNotified")]
        void OnNotified(int FirstNumber, int SecondNumber, System.Collections.Generic.Dictionary<int, ServiceReference.Player> OrderedPlayers);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface ISubscriberChannel : ServiceReference.ISubscriber, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class SubscriberClientBase : System.ServiceModel.DuplexClientBase<ServiceReference.ISubscriber>, ServiceReference.ISubscriber
    {
        
        public SubscriberClientBase(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress)
        {
        }
        
        public void InitPlayer(ServiceReference.Player player)
        {
            base.Channel.InitPlayer(player);
        }
        
        public System.Threading.Tasks.Task InitPlayerAsync(ServiceReference.Player player)
        {
            return base.Channel.InitPlayerAsync(player);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
    }
    
    public class OnNotifiedReceivedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {
        
        private object[] results;
        
        public OnNotifiedReceivedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState)
        {
            this.results = results;
        }
        
        public int FirstNumber
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
        
        public int SecondNumber
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[1]));
            }
        }
        
        public System.Collections.Generic.Dictionary<int, ServiceReference.Player> OrderedPlayers
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.Generic.Dictionary<int, ServiceReference.Player>)(this.results[2]));
            }
        }
    }
    
    public partial class SubscriberClient : SubscriberClientBase
    {
        
        public SubscriberClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                this(new SubscriberClientCallback(), binding, remoteAddress)
        {
        }
        
        private SubscriberClient(SubscriberClientCallback callbackImpl, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(new System.ServiceModel.InstanceContext(callbackImpl), binding, remoteAddress)
        {
            callbackImpl.Initialize(this);
        }
        
        public event System.EventHandler<OnNotifiedReceivedEventArgs> OnNotifiedReceived;
        
        private void OnOnNotifiedReceived(object state)
        {
            if ((this.OnNotifiedReceived != null))
            {
                object[] results = ((object[])(state));
                this.OnNotifiedReceived(this, new OnNotifiedReceivedEventArgs(results, null, false, null));
            }
        }
        
        private class SubscriberClientCallback : object, ISubscriberCallback
        {
            
            private SubscriberClient proxy;
            
            public void Initialize(SubscriberClient proxy)
            {
                this.proxy = proxy;
            }
            
            public void OnNotified(int FirstNumber, int SecondNumber, System.Collections.Generic.Dictionary<int, ServiceReference.Player> OrderedPlayers)
            {
                this.proxy.OnOnNotifiedReceived(new object[] {
                            FirstNumber,
                            SecondNumber,
                            OrderedPlayers});
            }
        }
    }
}
