using System;
namespace eu.sig.training.ch04.v1
{
    public class CheckingAccount
    {
        private int transferLimit = 100;

        public Transfer MakeTransfer(String counterAccount, Money amount)
        {
            _checkWithdrawalLimit(amount);
            _checkElevenTest(counterAccount);

            CheckingAccount acct = Accounts.FindAcctByNumber(counterAccount);
            return new Transfer(this, acct, amount);
        }

        private static void _checkElevenTest(string counterAccount)
        {
            // 2. Assuming result is 9-digit bank account number, validate 11-test:
            if (String.IsNullOrEmpty(counterAccount) || counterAccount.Length != 9)
            {
                throw new BusinessException("Invalid account number!");
            }
            int sum = 0;
            for (int i = 0; i < counterAccount.Length; i++)
            {
                sum = sum + (9 - i) * (int)Char.GetNumericValue(counterAccount[i]);
            }
            if (sum % 11 != 0)
            {
                throw new BusinessException("Invalid account number!");
            }
        }

        private void _checkWithdrawalLimit(Money amount)
        {
            // 1. Check withdrawal limit:
            if (amount.GreaterThan(this.transferLimit))
            {
                throw new BusinessException("Limit exceeded!");
            }
        }
    }
}