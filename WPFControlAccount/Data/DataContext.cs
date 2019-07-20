using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFControlAccount.Models;

namespace WPFControlAccount.Data
{
    public static class DataContext
    {
        public static IEnumerable<Account> GetAllAccounts()
        {
            //return new List<Account>()
            //{
            //    new Account{Initials = "LUZ", AccountName="ENERGIA ELÉTRICA" },
            //    new Account{Initials = "COND", AccountName="CONDOMÍNIO" },
            //    new Account{Initials = "AGU", AccountName="ÀGUA" }
            //};
            var ctx = new MyDbContext();
            return ctx.Accounts;
        }

        public static IEnumerable<LaunchAccount> GetAllLauchs()
        {
            var lauchs = new List<LaunchAccount>();
            Account account;

            account = GetAllAccounts().FirstOrDefault(a => a.Initials.Equals("LUZ"));
            lauchs.Add(new LaunchAccount { Account = account, AccountDate = new DateTime(2018, 1, 20), ExperitationDate = new DateTime(2018, 2, 28), AccountValue = 100.5m });

            account = GetAllAccounts().FirstOrDefault(a => a.Initials.Equals("COND"));
            lauchs.Add(new LaunchAccount { Account = account, AccountDate = new DateTime(2019, 5, 10), ExperitationDate = new DateTime(2019, 6, 15), AccountValue = 165 });

            account = GetAllAccounts().FirstOrDefault(a => a.Initials.Equals("AGU"));
            lauchs.Add(new LaunchAccount { Account = account, AccountDate = new DateTime(2019, 7, 1), ExperitationDate = new DateTime(2019, 7, 26), AccountValue = 15.6m });

            return lauchs;
        }
    }
}
