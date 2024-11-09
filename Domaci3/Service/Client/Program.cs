using ServiceReference;
using System.ServiceModel;

namespace Client
{
    class PlayerCallback : ISubscriberCallback
    {
        public void OnNotified(int FirstNumber, int SecondNumber, Dictionary<int, Player> OrderedPlayers)
        {
            Console.WriteLine($"Prvi broj: {FirstNumber}!");
            Console.WriteLine($"Drugi broj: {SecondNumber}!");

            int Rank = OrderedPlayers.Keys.ToList().IndexOf(Program.Player.Credentials.Id);
            Console.WriteLine($"Istorijski plasman: {Rank}!");

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
            EndpointAddress endpointAddress = new("http://localhost:55637/Service.svc/sub");
            ServiceReference = new(context, binding, endpointAddress);

            InitPlayer();
            Console.ReadLine();
        }

        static void InitPlayer()
        {
            Console.WriteLine("Unesite ime...");
            string? FirstName = Console.ReadLine();

            Console.WriteLine("Unesite prezime...");
            string? LastName = Console.ReadLine();

            Console.WriteLine("Unesite vaš id");
            int Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Unesite prvi broj...");
            int FirstNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Unesite drugi broj...");
            int SecondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Koliko ulažete novca...");
            int InvestedMoney = int.Parse(Console.ReadLine());

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
