using System;
namespace Uppgift1_CICD.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public int AccountBalance { get; set; }

        public Account(int accountID, int accountBalance)
        {
            this.AccountID = accountID;
            this.AccountBalance = accountBalance;
        }
    }
}
