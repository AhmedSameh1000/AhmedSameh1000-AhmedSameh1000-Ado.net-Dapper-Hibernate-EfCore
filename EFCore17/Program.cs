using C01.BasicSaveWithTracking.Data;
using EFCore17.Entities;
using EFCore17.Helper;

namespace EFCore17
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
        }
        public static void Run_Initial_Transfer_WalkThrowgh()
        {
            var Account1 = new BankAccount()
            {
               AccountId=1,
               AccountHolder="Ali Salim",
               CurrentBalance=1_000
            };

            var Account2 = new BankAccount()
            {
                AccountId = 2,
                AccountHolder = "Reem Saleh",
                CurrentBalance =1_000,
            };
            var Amount = 100;
            Account1.WithDrow(Amount);

            Account2.Deposit(Amount);
          
        }

        public static void Run_Changes_Within_Multiaple_SaveChanges()
        {
            DatabaseHelper.ReCreateDatabase();
            DatabaseHelper.PapulateDatabase();

            using var context = new AppDbContext();

            var Account1 = context.BankAccounts.FirstOrDefault(c => c.AccountId == 1);
            var Account2 = context.BankAccounts.FirstOrDefault(c => c.AccountId == 2);

            var Amount = 100;
            Account1.WithDrow(Amount);
            context.SaveChanges();
        
            if (new Random().Next(0, 3) == 0)
            {
                Console.WriteLine(Account1);
                Console.WriteLine(Account2);
                return;
            }

            Account2.Deposit(Amount);
            context.SaveChanges();
        }
        public static void Run_Changes_Within_Single_SaveChanges()
        {
            DatabaseHelper.ReCreateDatabase();
            DatabaseHelper.PapulateDatabase();

            using var context = new AppDbContext();

            var Account1 = context.BankAccounts.FirstOrDefault(c => c.AccountId == 1);
            var Account2 = context.BankAccounts.FirstOrDefault(c => c.AccountId == 2);

            var Amount = 100;
            Account1.WithDrow(Amount);

            if (new Random().Next(0, 3) == 0)
            {
                Console.WriteLine(Account1);
                Console.WriteLine(Account2);
                return;
            }
            Account2.Deposit(Amount);

            context.SaveChanges();
        }

        public static void Run_Changes_Within_Multiaple_SaveChanges_In_Db_Transaction()
        {
            DatabaseHelper.ReCreateDatabase();
            DatabaseHelper.PapulateDatabase();

            using (var context = new AppDbContext())
            {
                using (var Transaction = context.Database.BeginTransaction())
                {
                    var Account1 = context.BankAccounts.FirstOrDefault(c => c.AccountId == 1);
                    var Account2 = context.BankAccounts.FirstOrDefault(c => c.AccountId == 2);

                    var Amount = 100;
                    Account1.WithDrow(Amount);
                    context.SaveChanges();

                    Account2.Deposit(Amount);
                    context.SaveChanges();
                    
                    if(Amount == 100)
                    {
                        Console.WriteLine(Account1);
                        Console.WriteLine(Account2);
                        return;
                    }
                    
                    
                    Transaction.Commit();
                }
            }

        }

        public static void Run_Changes_Within_Multiaple_SaveChanges_In_Db_Transaction_Best_Practices()
        {
            DatabaseHelper.ReCreateDatabase();
            DatabaseHelper.PapulateDatabase();

            using (var context = new AppDbContext())
            {
                using (var Transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var Account1 = context.BankAccounts.FirstOrDefault(c => c.AccountId == 1);
                        var Account2 = context.BankAccounts.FirstOrDefault(c => c.AccountId == 2);

                        var Amount = 100;
                        Account1.WithDrow(Amount);
                        context.SaveChanges();

                        Account2.Deposit(Amount);
                        context.SaveChanges();

                        if (new Random().Next(0,3) == 100)
                        {
                            throw new InvalidOperationException();
                        }


                        Transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Transaction.Rollback();
                    }
                }
            }

        }

        public static void Run_Changes_Db_Transactions_Save_Points()
        {
            DatabaseHelper.ReCreateDatabase();
            DatabaseHelper.PapulateDatabase();

            using (var context = new AppDbContext())
            {
                using (var Transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var Account1 = context.BankAccounts.FirstOrDefault(c => c.AccountId == 1);
                        var Account2 = context.BankAccounts.FirstOrDefault(c => c.AccountId == 2);

                        Transaction.CreateSavepoint("Read_Amount");
                        var Amount = 100;
                        Account1.WithDrow(Amount);
                        context.SaveChanges();

                        Account2.Deposit(Amount);
                        context.SaveChanges();

                        if (new Random().Next(0, 2) == 0)
                        {
                            throw new InvalidOperationException();
                        }

                        Transaction.CreateSavepoint("Done");

                        Transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Transaction.RollbackToSavepoint("Read_Amount");
                    }
                }
            }

        }





    }
}