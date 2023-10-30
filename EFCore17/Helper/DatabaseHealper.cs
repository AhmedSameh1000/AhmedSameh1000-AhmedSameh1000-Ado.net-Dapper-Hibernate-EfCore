using C01.BasicSaveWithTracking.Data;
using EFCore17.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore17.Helper
{
    public static class DatabaseHelper
    {
        public static void ReCreateDatabase()
        {
            using var Context = new AppDbContext();
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }


        public static void PapulateDatabase()
        {
            using var context=new AppDbContext();   
            var BankAccounts = new List<BankAccount>()
            {
                new BankAccount {AccountId = 1,AccountHolder="Ahmed Ali",CurrentBalance=1_000m},
                new BankAccount {AccountId = 2,AccountHolder="Sameh Ahmed",CurrentBalance=1_000m},
                new BankAccount {AccountId = 3,AccountHolder="Rana Salem",CurrentBalance=1_000m},
            };
            context.BankAccounts.AddRange(BankAccounts);
            context.SaveChanges();
        }

    }
}

