using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavidMatevosyan_LuckySteps.Player;

namespace DavidMatevosyan_LuckySteps.LuckyStepGame
{
    public interface Game
    {
        public void RegisterPlayer(Player.Player player);
        public void TransferWinningAmount(double amount, Player.Player player);
    }
}
