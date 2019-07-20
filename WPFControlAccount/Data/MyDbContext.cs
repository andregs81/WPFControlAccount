using System.Data.Entity;
using WPFControlAccount.Models;

namespace WPFControlAccount.Data
{
    public class MyDbContext : DbContext
    {
        public IDbSet<Account> Accounts { get; set; }

        public MyDbContext()
            : base("myConnection")
        {
            Configure();
        }

        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelConfiguration.Configure(modelBuilder);

            var sqliteConnectionInitializer = new MyDbContextInitializer(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);


        }
    }
}
