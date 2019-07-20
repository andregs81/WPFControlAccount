using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFControlAccount.Models;

namespace WPFControlAccount.Data
{
    public class ModelConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            ConfigureAccount(modelBuilder);
        }

        private static void ConfigureAccount(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .ToTable("Base.Account")
                .Property(p => p.StartDate)
                .HasColumnAnnotation("Default", "(strftime('%s','now'))")
                .IsRequired();
        }
    }
}
