using System;

namespace eu.sig.training.ch04.v1
{
    public class SavingsAccount
    {
        public CheckingAccount RegisteredCounterAccount { get; set; }

        public Transfer makeTransfer(string counterAccount, Money amount)
        {
            _validateStructure(counterAccount);
            Transfer result = _makeTransfer(counterAccount, amount);
            _validateResult(result);
            return result;
        }

        private void _validateResult(Transfer result)
        {
            if (!result.CounterAccount.Equals(this.RegisteredCounterAccount))
            {
                throw new BusinessException("Counter-account not registered!");
            }
        }

        private Transfer _makeTransfer(string counterAccount, Money amount)
        {
            CheckingAccount acct = Accounts.FindAcctByNumber(counterAccount);
            Transfer result = new Transfer(this, acct, amount);
            return result;
        }

        private static void _validateStructure(string counterAccount)
        {
            // 1. Assuming result is 9-digit bank account number, validate 11-test:
            _checkLenght(counterAccount);
            int sum = 0;
            for (int i = 0; i < counterAccount.Length; i++)
            {
                sum = sum + (9 - i) * (int)Char.GetNumericValue(counterAccount[i]);
            }
            if (sum % 11 != 0)
            {
                throw new BusinessException("Invalid account number!!");
            }
        }

        private static void _checkLenght(string counterAccount)
        {
            if (String.IsNullOrEmpty(counterAccount) || counterAccount.Length != 9)
            {
                throw new BusinessException("Invalid account number!");
            }
        }
    }
}
