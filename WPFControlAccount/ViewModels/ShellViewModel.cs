using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using WPFControlAccount.Data;
using WPFControlAccount.Models;

namespace WPFControlAccount.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            LoadAccountPage();
            DisplayName = "Controle de Contas";
        }

        private string accountVisibility = "Hidden";

        public string AccountVisibility
        {
            get { return accountVisibility; }
            set
            {
                accountVisibility = value;
                NotifyOfPropertyChange(() => AccountVisibility);
            }
        }


        public void LoadAccountPage()
        {

            ActivateItem(new AccountViewModel());
        }

        public void LoadLaunchAccountPage()
        {
            ActivateItem(new LaunchAccountViewModel());
        }
    }
}
