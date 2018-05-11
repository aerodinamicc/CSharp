using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            var accountsFactory = new AccountsFactory();
            var savingsAccount = accountsFactory.GetSavingsAccount(line);
            Console.WriteLine(savingsAccount.Balance());
            Console.WriteLine(savingsAccount.Name());
            Console.ReadKey();
        }
    }

    public interface ISavingsAccount
    {
        decimal Balance();

        string Name();
    }

    public class UbbSavingsAccount : ISavingsAccount
    {
        public decimal Balance()
        {
            return 20;
        }

        public string Name()
        {
            return "UBB";
        }
    }

    public class DskSavingsAccount : ISavingsAccount
    {
        public decimal Balance()
        {
            return 10;
        }

        public string Name()
        {
            return "DSK";
        }
    }

    public interface IAccountsFactory
    {
        ISavingsAccount GetSavingsAccount(string accountNo);
    }

    public class AccountsFactory :IAccountsFactory
    {
        public ISavingsAccount GetSavingsAccount(string accountNo)
        {
            if (accountNo.Contains("ubb"))
            {
                return new UbbSavingsAccount();
            }
            if (accountNo.Contains("dsk"))
            {
                return new DskSavingsAccount();
            }

            throw new ArgumentException("Invalid account number.");
        }
    }
}
