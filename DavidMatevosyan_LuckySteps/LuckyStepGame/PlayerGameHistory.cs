using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidMatevosyan_LuckySteps.LuckyStepGame
{
    public static class PlayerGameHistory
    {
        public static Dictionary<Player.Player, Dictionary<int, DateTime>> PlayedRoundsCountByPlayer = new();
        public static void ResetRoundsCount()
        {
            foreach (var player in PlayedRoundsCountByPlayer)
            {
                if (player.Value.ContainsKey(3))
                {

                }
                else
                {
                    player.Value.Remove(1);
                    player.Value.Remove(2);
                }
            }
        }
    }
}
