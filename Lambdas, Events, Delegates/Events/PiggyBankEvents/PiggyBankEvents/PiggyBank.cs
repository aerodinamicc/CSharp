using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiggyBankEvents
{
    public delegate void UpdatedBalance(decimal newBalance);
    public delegate void ReachedAGoal(decimal balance);

    public class PiggyBank
    {
        private decimal _balance;
        private event UpdatedBalance BalanceUpdated = (x) => Console.WriteLine($"The balance is now {x}");
        private event ReachedAGoal ReachedAGoal = (x) => Console.WriteLine($"You've reached your goal! You have {x}");

        public PiggyBank()
        {
            _balance = 0m;
        }

        public void UpdateBalance(decimal update)
        {
            _balance += update;
            BalanceUpdated(_balance);
            if (_balance > 500)
            {
                ReachedAGoal(_balance);
            }
        }
    }
}
