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
        public delegate void OnNotifiedDelegate(int FirstNumber, int SecondNumber);
        public static event OnNotifiedDelegate OnNotifiedEvent;
        
        // Ne bi bilo loše zamijeniti bazom, mada iz jednostavnosti zadatka ostavljam rječnik.
        static Dictionary<int, (Player, ICallback)> Players = new Dictionary<int, (Player, ICallback)>();
        public static bool FirstCall = false;

        public Service()
        {
            if(!FirstCall)
            {
                OnNotifiedEvent += CallbackPlayers;
                FirstCall = true;
            }
        }

        public void Publish(int FirstNumber, int SecondNumber)
        {
            if (Players.Any())
            {
                OnNotifiedEvent?.Invoke(FirstNumber, SecondNumber);
            }
        }

        public void InitPlayer(Player player)
        {
            ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();

            if (Players.ContainsKey(player.Credentials.IdCardNumber))
            {
                bool isRightPlayer = Validator.CheckCredentials(player, Players);
                if (!isRightPlayer)
                {
                    callback.RegistrationStatus(Status.CredentialsNotCorrectFailure);
                    return;
                }

                Players[player.Credentials.IdCardNumber] = (Players[player.Credentials.IdCardNumber].Item1, callback);
                callback.RegistrationStatus(Status.AlreadyRegistredFailure);
                return;
            }

            Players.Add(player.Credentials.IdCardNumber, (player, callback));
            callback.RegistrationStatus(Status.Success);
            return;

        }

        static void CalculateBalances(int FirstNumber, int SecondNumber) 
        { 
            foreach((Player player, _) in Players.Values)
            {
                List<int> LotoMachineNumbers = new List<int> { FirstNumber, SecondNumber };
                int PlayerFirstNumber = player.Ticket.FirstNumber;
                int PlayerSecondNumber = player.Ticket.SecondNumber;

                if (LotoMachineNumbers.Contains(PlayerFirstNumber))
                {
                    if(LotoMachineNumbers.Contains(PlayerSecondNumber))
                    {
                        player.CurrentBalance += 5 * player.Ticket.InvestedMoney;
                        continue;
                    }
                    player.CurrentBalance += player.Ticket.InvestedMoney;
                    continue;
                }
                else if(LotoMachineNumbers.Contains(PlayerSecondNumber))
                {
                    player.CurrentBalance += player.Ticket.InvestedMoney;
                    continue;
                }
                player.CurrentBalance -= player.Ticket.InvestedMoney;
            }
        }

        static List<(Player, ICallback)> OrderPlayers()
        {
            return Players.OrderByDescending(kvp => kvp.Value.Item1.CurrentBalance).Select(kvp => kvp.Value).ToList();
        }

        static void CallbackPlayers(int FirstNumber, int SecondNumber)
        {
            CalculateBalances(FirstNumber, SecondNumber);
            List<(Player, ICallback)> OrderedPlayers = OrderPlayers();

            for (int i = 0; i < OrderedPlayers.Count; i++)
            {
                (Player player, ICallback callback) = OrderedPlayers[i];
                callback.NotifyPlayer(FirstNumber, SecondNumber, i + 1, player);
            }
        }
    }
}
