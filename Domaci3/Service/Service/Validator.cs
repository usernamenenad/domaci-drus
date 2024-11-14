using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Service
{
    internal class Validator
    {
        public static bool CheckCredentials(Player player, Dictionary<int, (Player, ICallback)> Players)
        {
            (Player rightPlayer, _) = Players[player.Credentials.IdCardNumber];

            if (rightPlayer.Credentials.FirstName == player.Credentials.FirstName && rightPlayer.Credentials.LastName == player.Credentials.LastName)
            {
                return true;
            }
            return false;
        }
    }
}