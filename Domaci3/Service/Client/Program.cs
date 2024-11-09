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
