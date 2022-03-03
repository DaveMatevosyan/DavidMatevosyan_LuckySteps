using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidMatevosyan_LuckySteps.Player
{
    public class Player : IPlayer
    {
        private int _ID;
        private string _UserName;
        private double _Balance = 0;
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }
        public double Balance
        {
            get
            {
                return _Balance;
            }
        }
        public Player(int ID, string UserName)
        {
            this.ID = ID;
            this.UserName = UserName;
        }
        public void TransferToBalance(double amount)
        {
            if (amount >= 0)
            {
                _Balance += amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Amount");
            }
        }
        public double CheckBalance()
        {
            return this.Balance;
        }
    }
}
