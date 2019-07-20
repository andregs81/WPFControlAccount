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
            Launchs.AddRange(DataContext.GetAllLauchs());
            Accounts.AddRange(DataContext.GetAllAccounts());
        }

        public BindableCollection<Account> Accounts { get; }
        public BindableCollection<LaunchAccount> Launchs { get; set; }

        public string Label => "Lançamento de Contas";

        private DateTime accountDate = DateTime.Now;
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
                NotifyOfPropertyChange(() => CanAddLauch);

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
                NotifyOfPropertyChange(() => CanAddLauch);
            }
        }

        public bool CanAddLauch
        {
            get { return IsValid(); }
        }

        private bool IsValid()
        {
            return AccountValue > 0 && SelectedAccount != null;
        }

        private void ClearLauchForm()
        {
            this.AccountValue = 0;
            this.SelectedAccount = null;
            this.AccountDate = DateTime.Now;
        }

        public void AddLauch()
        {
            Launchs.Add(new LaunchAccount { Account = SelectedAccount, AccountDate = AccountDate,  ExperitationDate = ExperitationDate, AccountValue = AccountValue });
            ClearLauchForm();
        }
    }
}
