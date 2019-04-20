using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFControlAccount.Models
{
    public class LaunchAccount
    {
        public LaunchAccount()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; set; }
        public DateTime AccountDate { get; set; }
        public DateTime ExperitationDate { get; set; }
        public Account Account { get; set; }
        public decimal AccountValue { get; set; }
    }
}
