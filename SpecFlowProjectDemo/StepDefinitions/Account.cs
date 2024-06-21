using SpecFlowProjectDemo.StepDefinitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject2.StepDefinitions
{
    public class Account
    {
        private string accountNumber;
        private string accountName;
        private double balance;
        public string Id { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }

        private List<Transaction> transactions; // Corrected name and declaration

        public Account(string accountNumber, string accountName)
        {
            this.accountNumber = accountNumber;
            this.accountName = accountName;
            this.transactions = new List<Transaction>(); // Corrected initialization
        }

        public void Deposit(string id, double amount, string date)
        {
            transactions.Add(new Transaction(id, amount, date)); // Corrected name and usage
            balance += amount;
        }

        public void Withdraw(string id, double amount, string date)
        {
            transactions.Add(new Transaction(id, -amount, date)); // Corrected name and usage
            balance -= amount;
        }

        public void ProduceStatement()
        {
            // Produce statement logic (if needed)
        }

        public string GetStatement()
        {
            StringBuilder statement = new StringBuilder();
            statement.AppendLine($"Name: {accountName}");
            statement.AppendLine($"Account: {accountNumber}");
            statement.AppendLine($"Balance: {balance}");
            foreach (var tr in transactions) // Corrected variable name
            {
                statement.AppendLine($"{tr.Date}: {tr.Id}: {tr.Amount}"); // Corrected property access
            }
            Console.WriteLine(statement.ToString());

            return statement.ToString();
        }

        public List<Transaction> GetTransactions()
        {
            return transactions; // Corrected variable name
        }

        public double GetBalance()
        {
            return balance;
        }

        public string GetAccountNumber()
        {
            return accountNumber;
        }

        public string GetAccountName()
        {
            return accountName;
        }
    }
}
