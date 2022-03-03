using DavidMatevosyan_LuckySteps.LuckyStepGame;
using DavidMatevosyan_LuckySteps.Player;

Player player = new Player(1, "David");
LuckySteps luckySteps = new LuckySteps();
Console.WriteLine(player.CheckBalance());
luckySteps.LaunchGame(player);
Console.WriteLine(player.CheckBalance());
Console.ReadLine();


