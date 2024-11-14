using ServiceReference;
using System.Diagnostics;
using System.ServiceModel;

namespace Client
{
    class PlayerCallback : ISubscriberCallback
    {
        // Sa servera stiže podatak o istorijskom plasmanu igrača, kao i sam igrač iz čije instance se izvlače podacic
        // o trenutnom stanju na računu.
        public void NotifyPlayer(int FirstNumber, int SecondNumber, int Rank, Player player)
        {
            Console.WriteLine($"Brojevi na tiketu: {player.Ticket.FirstNumber}, {player.Ticket.SecondNumber}.");
            Console.WriteLine($"Izvučeni brojevi na lotu: {FirstNumber}, {SecondNumber}.");
            Console.WriteLine($"Uloženo: {player.Ticket.InvestedMoney}.");
            Console.WriteLine($"Trenutno stanje: {player.CurrentBalance}");
            Console.WriteLine($"Istorijski plasman: {Rank}.");

            Console.WriteLine("-----------------------------");
        }

        // Callback metoda koja služi za provjeru pri preplaćivanju igrača na igru.
        // Više o ovome u Service.Status enum klasi.
        public void RegistrationStatus(Status status)
        {
            switch (status) 
            {
                case Status.Success:
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Igrač uspješno registrovan!");
                    Console.WriteLine("-----------------------------");
                    break;

                case Status.AlreadyRegistredFailure:
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Igrač je već uplatio tiket!");
                    Console.WriteLine("-----------------------------");
                    break;

                case Status.CredentialsNotCorrectFailure:
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Lažni kredencijali! Igrač ne može igrati igru!");
                    Console.WriteLine("-----------------------------");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                break;
            }
        }
    }
    internal class Program
    {
        static SubscriberClientBase? ServiceReference;
        static void Main(string[] args)
        {
            InstanceContext context = new(new PlayerCallback());
            WSDualHttpBinding binding = new();
            EndpointAddress endpointAddress = new("http://localhost:57079/Service.svc/sub");
            ServiceReference = new(context, binding, endpointAddress);

            InitPlayer();
            Console.ReadLine();
        }
        static void InitPlayer()
        {
            string FirstName = "";
            string LastName = "";
            Validator.ValidateFirstAndLastName(ref FirstName, ref LastName);

            int IdCardNumber = -1;
            Validator.ValidateIdCardNumber(ref IdCardNumber);

            int FirstNumber = -1;
            int SecondNumber = -1;
            Validator.ValidateFirstAndSecondNumber(ref FirstNumber, ref SecondNumber);

            int InvestedMoney = -1;
            Validator.ValidateInvestedMoney(ref InvestedMoney);

            Player p = new()
            {
                Credentials = new()
                {
                    IdCardNumber = IdCardNumber,
                    FirstName = FirstName,
                    LastName = LastName
                },
                Ticket = new()
                {
                    FirstNumber = FirstNumber,
                    SecondNumber = SecondNumber,
                    InvestedMoney = InvestedMoney
                },
                CurrentBalance = 0
            };

            ServiceReference?.InitPlayer(p);
        }
    }
}
