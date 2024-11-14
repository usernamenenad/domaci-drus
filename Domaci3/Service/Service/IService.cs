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
        void NotifyPlayer(int FirstNumber, int SecondNumber, int Rank, Player player);

        [OperationContract(IsOneWay = true)]
        void RegistrationStatus(Status status);
    }

    [DataContract]
    public class Credentials
    {
        [DataMember]
        public int IdCardNumber;

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

    [DataContract]
    public enum Status
    {
        // Ako je igrač "unikatan", uspješno će biti registrovan.
        [EnumMember]
        Success,

        // Ako je igrač sa istim imenom, prezimenom i brojem lične karte već registovan,
        // ne dozvoljava mu se uplata još jednog tiketa.
        [EnumMember]
        AlreadyRegistredFailure,

        // Ako se igrač pokuša registrovati sa brojem lične karte koji je već registrovan, ali sa drugim imenom i prezimenom,
        // tretira se kao maliciozan pokušaj registracije na "nečije ime", te se "ubija" proces koji
        // se pokušao pretplatiti.
        [EnumMember]
        CredentialsNotCorrectFailure
    }
}
