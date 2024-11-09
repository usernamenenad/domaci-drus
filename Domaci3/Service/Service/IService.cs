using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    [ServiceContract]
    public interface IPublisher
    {
        [OperationContract(IsOneWay = true)]
        void Publish(int FirstNumber, int SecondNumber);
    }

    [ServiceContract(CallbackContract = typeof(ICallback), SessionMode = SessionMode.Required)]
    public interface ISubscriber
    {
        [OperationContract(IsOneWay = true)]
        void InitPlayer(Player player);
    }

    [ServiceContract]
    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void OnNotified(int FirstNumber, int SecondNumber, Dictionary<int, Player> OrderedPlayers);
    }

    [DataContract]
    public class Credentials
    {
        [DataMember]
        public int Id;

        [DataMember]
        public string FirstName;

        [DataMember]
        public string LastName;
    }

    [DataContract]
    public class Ticket
    {
        [DataMember]
        public int FirstNumber;

        [DataMember]
        public int SecondNumber;

        [DataMember]
        public int InvestedMoney;
    }

    [DataContract]
    public class Player
    {
        [DataMember]
        public Credentials Credentials;

        [DataMember]
        public Ticket Ticket;

        [DataMember]
        public int CurrentBalance;
    }
}
