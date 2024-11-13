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
        
        // Ne bi bilo loše zamijeniti bazom, mada iz jednostavnosti zadatka ostavljam rječnik.
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
            // Ako se pojavi igrač sa istim Id-em, neće biti upisan!
            // Međutim, klijent će ostati uvijek "zakopan" i čekaće zauvijek na event,
            // iako nije registrovan ni na kakav.
            // Rješenje - dodati i neki callback za Id.
            if(!Players.ContainsKey(player.Credentials.Id))
            {
                ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
                Players.Add(player.Credentials.Id, player);
                OnNotifiedEvent += callback.OnNotified;
            }
        }

        static void CalculateBalances(int FirstNumber, int SecondNumber) 
        { 
            foreach(Player player in Players.Values)
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

        static Dictionary<int, Player> OrderPlayers()
        {
            return Players.OrderByDescending(kvp => kvp.Value.CurrentBalance).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        static void CallbackPlayers(int FirstNumber, int SecondNumber, Dictionary<int, Player> OrderedPlayers)
        {
            // Ovako eventujemo sve igrače i dajemo im čitavu rang listu, pa oni sami
            // izvlače koji su. Da bi to uradili na serverskoj strani, ili ćemo za svakog igrača
            // imati poseban event, ili uopšte nećemo koristiti eventove, već pozivati neku
            // callback metodu. 
            OnNotifiedEvent?.Invoke(FirstNumber, SecondNumber, OrderedPlayers);
        }
    }
}
