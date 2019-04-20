using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFControlAccount.Models
{
    public class Account
    {
        public Account()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; set; }
        public string Initials { get; set; }
        public string AccountName { get; set; }
    }
}
