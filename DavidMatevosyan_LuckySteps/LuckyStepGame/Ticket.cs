namespace DavidMatevosyan_LuckySteps.LuckyStepGame
{
    public enum RowSide
    {
        Right = 1,
        Left = 2
    }

    public class Ticket
    {
        public RowSide Side { get; set; }
        public double WinningAmount { get; set; }
        public byte OrderInList { get; set; }
        public bool IsPlayed { get; set; } = false;
        public Ticket(RowSide _Side, double _WinningAmount, byte _OrderInList)
        {
            Side = _Side;
            WinningAmount = _WinningAmount;
            OrderInList = _OrderInList;
        }

    }
}
