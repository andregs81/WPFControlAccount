using Caliburn.Micro;
using System;
using System.Linq;
using System.Windows;
using WPFControlAccount.Data;
using WPFControlAccount.Models;

namespace WPFControlAccount.ViewModels
{
    public class AccountViewModel : Screen
    {
        public AccountViewModel()
        {
            //ID = Guid.NewGuid();
            Accounts = new BindableCollection<Account>();
            Accounts.AddRange(DataContext.GetAllAccounts());
        }
        private Guid id;

        public Guid ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string initial;

        public string Initial
        {
            get { return initial; }
            set
            {
                initial = value;
                NotifyOfPropertyChange(() => Initial);
                NotifyOfPropertyChange(() => CanAddAccount);
                NotifyOfPropertyChange(() => Accounts);
            }
        }

        private string accountName;

        public string AccountName
        {
            get { return accountName; }
            set
            {
                accountName = value;
                NotifyOfPropertyChange(() => AccountName);
                NotifyOfPropertyChange(() => CanAddAccount);
                NotifyOfPropertyChange(() => Accounts);
            }
        }

        public BindableCollection<Account> Accounts { get; set; }

        public bool CanAddAccount => IsValid();
        public void AddAccountAsync()
        {
            if (IsValid())
            {
                Accounts.Add(new Account { Initials = Initial, AccountName = AccountName });
                ClearAllFiles();
            }
            else
            {
                MessageBox.Show("Nem todos os campos foram preenchidos!!!");
            }
        }

        public void Update()
        {
            var account = Accounts.FirstOrDefault(a => a.ID == ID);
            account.AccountName = AccountName;
            account.Initials = Initial;
            Accounts.Refresh();
            ClearAllFiles();
        }

        public void Save()
        {
            if (ID == Guid.Empty)
                AddAccountAsync();
            else
                Update();
        }

        private bool IsValid()
        {
            return !(string.IsNullOrEmpty(Initial) || string.IsNullOrEmpty(AccountName));
        }

        private void ClearAllFiles()
        {
            Initial = "";
            AccountName = "";
            ID = Guid.Empty;
        }

        public void SetValue(Account source)
        {
            Initial = source.Initials;
            AccountName = source.AccountName;
            ID = source.ID;
        }

    }
}
