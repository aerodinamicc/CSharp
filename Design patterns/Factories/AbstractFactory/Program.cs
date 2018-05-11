using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new Factory();
            var accountsFactory = factory.GetAccountsFactory(Console.ReadLine());
            var loan = accountsFactory.CreateLoanAccount();
            var savings = accountsFactory.CreateSavingsAccount();
            Console.WriteLine(loan.MonthlyTax());
            Console.WriteLine(savings.Balance());
            Console.ReadKey();
        }
    }

    //Factories
    public interface IFactory
    {
        IAccountsFactory GetAccountsFactory(string account);
    }

    public interface IAccountsFactory
    {
        ILoanAccount CreateLoanAccount();

        ISavingsAccount CreateSavingsAccount();
    }

    //Accounts
    public interface ISavingsAccount
    {
        decimal Balance();
    }

    public interface ILoanAccount
    {
        decimal MonthlyTax();
    }

    //Concrete factories
    public class Factory : IFactory
    {
        public IAccountsFactory GetAccountsFactory(string account)
        {
            if (account.Contains("ubb"))
            {
                return new UbbAccountFactory();
            }

            if (account.Contains("dsk"))
            {
                return new DskAccountFactory();
            }
            
            throw new ArgumentException("Invalid ");
        }
        
    }

    public class UbbAccountFactory : IAccountsFactory
    {
        public ILoanAccount CreateLoanAccount()
        {
            return new UbbLoanAccount();
        }

        public ISavingsAccount CreateSavingsAccount()
        {
            return new UbbSavingsAccount();
        }
    }

    public class DskAccountFactory : IAccountsFactory
    {
        public ILoanAccount CreateLoanAccount()
        {
            return new DskLoanAccount();
        }

        public ISavingsAccount CreateSavingsAccount()
        {
            return new DskSavingsAccount();
        }
    }

    //Concrete accounts
    public class DskSavingsAccount : ISavingsAccount
    {
        public decimal Balance()
        {
            return 1000;
        }
    }

    public class DskLoanAccount : ILoanAccount
    {
        public decimal MonthlyTax()
        {
            return 100;
        }
    }

    public class UbbSavingsAccount : ISavingsAccount
    {
        public decimal Balance()
        {
            return 2000;
        }
    }

    public class UbbLoanAccount : ILoanAccount
    {
        public decimal MonthlyTax()
        {
            return 500;
        }
    }
}
