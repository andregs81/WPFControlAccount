using SQLite.CodeFirst;
using System.Collections.Generic;
using System.Data.Entity;
using WPFControlAccount.Models;

namespace WPFControlAccount.Data
{
    public class MyDbContextInitializer : SqliteDropCreateDatabaseWhenModelChanges<MyDbContext>
    {
        public MyDbContextInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder)
        {
        }

        protected override void Seed(MyDbContext context)
        {
            context.Set<Account>()
                .AddRange(
                            new List<Account>()
                            {
                                new Account{Initials = "LUZ", AccountName="ENERGIA ELÉTRICA" },
                                new Account{Initials = "COND", AccountName="CONDOMÍNIO" },
                                new Account{Initials = "AGU", AccountName="ÀGUA" },
                                new Account{Initials = "DSD", AccountName="DESPESAS DIVERSAS" }
                            }
            );
            context.SaveChanges();
        }
    }
}
