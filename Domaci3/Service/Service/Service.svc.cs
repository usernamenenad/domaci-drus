using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace Service
{
    public class Service : IPublisher, ISubscriber
    {
        public delegate void OnNotifiedDelegate(int FirstNumber, int SecondNumber, Dictionary<int, Player> OrderedPlayers);
        public static event OnNotifiedDelegate OnNotifiedEvent;
        static Dictionary<int, Player> Players = new Dictionary<int, Player>();

        public void Publish(int FirstNumber, int SecondNumber)
        {
            if (Players.Any())
            {
                CalculateBalances(FirstNumber, SecondNumber);
                CallbackPlayers(FirstNumber, SecondNumber, OrderPlayers());
            }
        }

        public void InitPlayer(Player player)
        {
            ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            if(Players.ContainsKey(player.Credentials.Id))
            {
                //
            }
            Players.Add(player.Credentials.Id, player);
            OnNotifiedEvent += callback.OnNotified;
        }

        static void CalculateBalances(int FirstNumber, int SecondNumber) 
        { 
            foreach(Player player in Players.Values)
            {
                int PlayerFirstNumber = player.Ticket.FirstNumber;
                int PlayerSecondNumber = player.Ticket.SecondNumber;

                if (PlayerFirstNumber == FirstNumber && PlayerSecondNumber == SecondNumber)
                {
                    player.CurrentBalance += 5 * player.Ticket.InvestedMoney;
                    continue;
                }
                if (PlayerFirstNumber == FirstNumber ^ PlayerSecondNumber == SecondNumber)
                {
                    player.CurrentBalance += player.Ticket.InvestedMoney;
                    continue;
                }
                player.CurrentBalance -= player.Ticket.InvestedMoney;
            }
        }

        static Dictionary<int, Player> OrderPlayers()
        {
            return Players.OrderBy(kvp => kvp.Value.CurrentBalance).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        static void CallbackPlayers(int FirstNumber, int SecondNumber, Dictionary<int, Player> OrderedPlayers)
        {
            OnNotifiedEvent?.Invoke(FirstNumber, SecondNumber, OrderedPlayers);
        }
    }
}
