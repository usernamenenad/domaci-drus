using ServiceReference;
using System.ServiceModel;

namespace Client
{
    class PlayerCallback : ISubscriberCallback
    {
        // Traženje informacija na klijentskoj strani. Vjerovatno je bolje to odraditi na serveru, a da
        // se "preko žice" samo prebace potrebno podaci, a ne svi igrači. Međutim, gubi smisao
        // "Sub" dio "PubSub"-a, jer se samo obavještava svaki igrač pojedinačno, a ne svi odjednom.
        public void OnNotified(int FirstNumber, int SecondNumber, Dictionary<int, Player> OrderedPlayers)
        {
            int Rank = OrderedPlayers.Keys.ToList().IndexOf(Program.Player.Credentials.Id);
            Player Player = OrderedPlayers.Values.ToList()[Rank];

            Console.WriteLine($"Brojevi na tiketu: {Player.Ticket.FirstNumber}, {Player.Ticket.SecondNumber}.");
            Console.WriteLine($"Izvučeni brojevi na lotu: {FirstNumber}, {SecondNumber}.");
            Console.WriteLine($"Uloženo: {Player.Ticket.InvestedMoney}.");
            Console.WriteLine($"Trenutno stanje: {Player.CurrentBalance}");
            Console.WriteLine($"Istorijski plasman: {Rank + 1}.");

            Console.WriteLine("-----------------------------");
        }
    }
    internal class Program
    {
        static SubscriberClientBase? ServiceReference;
        public static Player? Player;
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
            Validator.ValidateFirstAndLastName(FirstName, LastName);

            int Id = -1;
            Validator.ValidateId(ref Id);

            int FirstNumber = -1;
            int SecondNumber = -1;
            Validator.ValidateFirstAndSecondNumber(ref FirstNumber, ref SecondNumber);

            int InvestedMoney = -1;
            Validator.ValidateInvestedMoney(ref InvestedMoney);

            Player = new()
            {
                Credentials = new()
                {
                    Id = Id,
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

            ServiceReference?.InitPlayer(Player);
        }
    }
}
