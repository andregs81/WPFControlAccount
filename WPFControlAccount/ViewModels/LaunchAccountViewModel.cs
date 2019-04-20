using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFControlAccount.Data;
using WPFControlAccount.Models;

namespace WPFControlAccount.ViewModels
{
    public class LaunchAccountViewModel : Screen
    {

        public LaunchAccountViewModel()
        {
            Accounts = new BindableCollection<Account>();
            Launchs = new BindableCollection<LaunchAccount>();
            Accounts.AddRange(DataContext.GetAllAccounts());
        }

        public BindableCollection<Account> Accounts { get; }
        public BindableCollection<LaunchAccount> Launchs { get; set; }

        private DateTime accountDate;
        public DateTime AccountDate
        {
            get
            {
                return accountDate;
            }
            set
            {
                if (accountDate == value)
                    return;

                accountDate = value;
                NotifyOfPropertyChange(() => AccountDate);
            }
        }

        private DateTime expirationDate = DateTime.Now.AddDays(1);
        public DateTime ExperitationDate
        {
            get
            {
                return expirationDate;
            }
            set
            {
                if (expirationDate == value)
                    return;

                expirationDate = value;
                NotifyOfPropertyChange(() => ExperitationDate);
            }
        }

        private decimal accountValue;
        public decimal AccountValue
        {
            get { return accountValue; }
            set
            {
                if (accountValue == value)
                    return;

                accountValue = value;
                NotifyOfPropertyChange(() => AccountValue);
                NotifyOfPropertyChange(() => Launchs);
            }
        }

        private Account selectedAccount;
        public Account SelectedAccount
        {
            get { return selectedAccount; }
            set
            {
                selectedAccount = value;
                NotifyOfPropertyChange(() => SelectedAccount);
            }
        }

        public void AddLauch() => Launchs.Add(new LaunchAccount { Account = SelectedAccount, ExperitationDate = ExperitationDate, AccountValue = AccountValue });

    }
}
