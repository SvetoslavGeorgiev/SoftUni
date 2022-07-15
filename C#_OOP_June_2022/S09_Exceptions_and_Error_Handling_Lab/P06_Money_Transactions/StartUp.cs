namespace P06_Money_Transactions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var accountsInfo = Console.ReadLine().Split('\u002C');
            var accounts = new List<Account>();
            string command;

            foreach (var account in accountsInfo)
            {
                var tokens = account.Split("-");
                var newAccount = new Account(tokens[0], decimal.Parse(tokens[1]));
                accounts.Add(newAccount);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                var tokens = command.Split(" ");

                var action = tokens[0];

                try
                {
                    if (action == "Deposit")
                    {
                        var account = accounts.FirstOrDefault(x => x.Id == tokens[1]);
                        if (account == null)
                        {
                            throw new ArgumentException("Invalid account!");
                        }
                        account.Add(decimal.Parse(tokens[2]));
                        Console.WriteLine($"Account {account.Id} has new balance: {account.Balance}");
                    }
                    else if (action == "Withdraw")
                    {
                        var account = accounts.FirstOrDefault(x => x.Id == tokens[1]);
                        if (account == null)
                        {
                            throw new ArgumentException("Invalid account!");
                        }
                        account.Subtract(decimal.Parse(tokens[2]));
                        Console.WriteLine($"Account {account.Id} has new balance: {account.Balance:F2}");
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid command!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }


    public class Account
    {

        private string id;

        private decimal balance;

        public Account(string id, decimal balance)
        {
            Id = id;
            Balance = balance;
        }

        public decimal Balance
        {
            get => balance;
            private set
            {
                balance = value;
            }
        }

        public string Id
        {
            get => id;
            private set
            {
                id = value;
            }
        }


        public void Add(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Insufficient amount!");
            }

            Balance += amount;
        }

        public void Subtract(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Insufficient amount!");
            }
            else if (Balance < amount)
            {
                throw new ArgumentException("Insufficient balance!");
            }

            Balance -= amount;
        }

    }
}
