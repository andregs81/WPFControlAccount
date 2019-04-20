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
        private static IEnumerable<Account> Accounts { get; set; }

        public static IEnumerable<Account> GetAllAccounts()
        {
            return new List<Account>()
            {
                new Account{Initials = "LUZ", AccountName="Energia elétrica" },
                new Account{Initials = "COND", AccountName="Condomínio" },
                new Account{Initials = "AGU", AccountName="ÀGUA" }
            }; 
        }
    }
}
