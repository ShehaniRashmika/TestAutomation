using System;

namespace SpecFlowProject2.StepDefinitions
{
    public class Transaction
    {
        public string Id { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }

        public Transaction(string id, double amount, string date)
        {
            Id = id;
            Amount = amount;
            Date = date;
        }
    }
}
