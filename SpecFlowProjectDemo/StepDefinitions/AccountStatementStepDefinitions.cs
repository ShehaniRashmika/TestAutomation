using TechTalk.SpecFlow.Assist;
using NUnit.Framework;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class AccountStatementStepDefinitions
    {
        private Account account;
        private string statement;

        //List<Transaction> transaction;
        [Given(@"Account exists for Acc No\. ""([^""]*)"" with Name ""([^""]*)""")]
        public void GivenAccountExistsForAccNo_WithName(string AccNumber, string Name)
        {
            account = new Account(AccNumber, Name);
        }

        [Given(@"deposits are made")]
        public void GivenDepositsAreMade(Table table)
        {
            var transactions = table.CreateSet<Transaction>();
            foreach (var transaction in transactions)
            {

                account.Deposit(transaction.Id, transaction.Amount, transaction.Date);
            }

        }

        [Given(@"withdrawals are made")]
        public void GivenWithdrawalsAreMade(Table table)
        {
            var transactions = table.CreateSet<Transaction>();
            foreach (var withdrawal in transactions)
            {
                account.Withdraw(withdrawal.Id, withdrawal.Amount, withdrawal.Date);
            }
        }
        [When(@"statement is produced")]
        public void WhenStatementIsProduced()
        {
            statement = account.GetStatement();
        }

        [Then(@"the statement includes ""([^""]*)""")]
        public void ThenTheStatementIncludes(string expectedText)
        {
            Assert.IsTrue(statement.Contains(expectedText), $"The statement does not include the expected text: {expectedText}");
        }
    }
}