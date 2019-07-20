using Caliburn.Micro;
using System;
using System.Linq;
using System.Windows;
using WPFControlAccount.Data;
using WPFControlAccount.Data.Repository;
using WPFControlAccount.Models;

namespace WPFControlAccount.ViewModels
{
    public class AccountViewModel : Screen
    {
        public BindableCollection<Account> Accounts { get; set; }
        private readonly IRepository<Account> repo;
        public AccountViewModel()
        {
            repo = new Repository<Account>();
            Accounts = new BindableCollection<Account>();
            Accounts.AddRange(DataContext.GetAllAccounts());
        }

        public string Label => "Cadastro de Contas";

        private Guid ID { get; set; }

        private string initial;
        public string Initial
        {
            get { return initial; }
            set
            {
                initial = value;
                NotifyOfPropertyChange(() => Initial);
                NotifyOfPropertyChange(() => Accounts);
                NotifyOfPropertyChange(() => CanSave);
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
                NotifyOfPropertyChange(() => Accounts);
                NotifyOfPropertyChange(() => CanSave);
            }
        }

        public void AddAccountAsync()
        {
            if (IsValid())
            {
                repo.Add(new Account { AccountName = AccountName, Initials = Initial });
                repo.Commit();
                UpdateList();
                ClearAllFiles();
            }
            else
            {
                MessageBox.Show("Nem todos os campos foram preenchidos!!!");
            }
        }

        private void UpdateList()
        {
            Accounts.Clear();
            Accounts.AddRange(DataContext.GetAllAccounts());
        }

        private bool IsValid()
        {
            return !(string.IsNullOrEmpty(Initial) || string.IsNullOrEmpty(AccountName));
        }

        private void ClearAllFiles()
        {
            Initial = "";
            AccountName = "";
        }

        public void SetValue(Account source)
        {
            Initial = source.Initials;
            AccountName = source.AccountName;
            ID = source.ID;
        }

        public void Update()
        {
            var account = Accounts.FirstOrDefault(a => a.ID == ID);
            account.AccountName = AccountName;
            account.Initials = Initial;
            Accounts.Refresh();
            ClearAllFiles();
        }

        public bool CanSave => IsValid();
        public void Save()
        {
            if (ID == Guid.Empty)
                AddAccountAsync();
            else
                Update();
        }
    }
}
