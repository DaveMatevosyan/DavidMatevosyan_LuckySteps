using DavidMatevosyan_LuckySteps.Player;

namespace DavidMatevosyan_LuckySteps.LuckyStepGame
{
    public class LuckySteps
    {
        private List<Ticket> WinnerTickets = new();
        private Player.Player Player;
        public event Action StartRound;


        private List<Ticket> TicketsGeneratorForRound(double startWinningAmount)
        {
            List<Ticket> tickets = new();
            for (byte i = 0; i < 10; i++)
            {
                Random random = new Random();
                tickets.Add(new Ticket((RowSide)random.Next(1, 3), startWinningAmount, ++i));
                --i;
                startWinningAmount *= 2;
            }
            return tickets;
        }
        public void LaunchGame(Player.Player player)
        {
            try
            {
                RegisterPlayer(player);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            WinnerTickets = TicketsGeneratorForRound(100);
            double amount = 0;
            foreach (Ticket ticket in WinnerTickets)
            {
                int option = ChooseAnOption(ticket);
                //log player's move
                switch (option)
                {
                    case 1:
                        if (IsMoveWinner((RowSide)1, ticket))
                        {
                            amount += ticket.WinningAmount;
                            Console.WriteLine("Right choice!!! You have won" + ticket.WinningAmount + " and now your prize is " + amount + ".");
                            //log move result
                        }
                        else
                        {
                            Console.WriteLine("Oops, wrong choice. Good look in next time.");
                            //log move result
                            return;
                        }
                        break;
                    case 2:
                        if (IsMoveWinner((RowSide)2, ticket))
                        {
                            amount += ticket.WinningAmount;
                            Console.WriteLine("Right choice!!! You have won" + ticket.WinningAmount + " and now your prize is " + amount + ".");
                            //log move result
                        }
                        else
                        {
                            Console.WriteLine("Oops, wrong choice. Good look in next time.");
                            //log move result
                            return;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Your winning amount is " + amount + ". Thanks for gaming.");
                        //log move result
                        return;
                    default:

                        break;
                }
            }
            TransferWinningAmount(amount, player);
            Console.WriteLine();


        }
        private void RegisterPlayer(Player.Player player)
        {
            try
            {
                PlayerGameHistory.PlayedRoundsCountByPlayer.Add(player, new Dictionary<int, DateTime> { { 1, DateTime.UtcNow } });
                Player = player;
            }
            catch (Exception ex)
            {
                    if (PlayerGameHistory.PlayedRoundsCountByPlayer[player].ContainsKey(3))
                    {
                        throw new ArgumentException("Today " + player.UserName + " already played 3 times.");
                    }
                    else
                    {
                        int alreadyPlayedGamesCount = PlayerGameHistory.PlayedRoundsCountByPlayer[player].Last().Key;
                        PlayerGameHistory.PlayedRoundsCountByPlayer.Add(player, new Dictionary<int, DateTime> { { alreadyPlayedGamesCount++, DateTime.UtcNow } });
                        Player = player;
                    }
            }
        }
        private void TransferWinningAmount(double amount, Player.Player player)
        {
            player.TransferToBalance(amount);
        }
        private int ChooseAnOption(Ticket ticket)
        {
            Console.WriteLine("You are on " + ticket.OrderInList + " step, please choose an option.\n 1.Right   2.Left   3.Exit.");
            int option = 0;
            do
            {
                int.TryParse(Console.ReadLine(), out option);
            }
            while (option < 0);
            return option;
        }
        private bool IsMoveWinner(RowSide side, Ticket ticket)
        {
            if (ticket.Side == side)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
