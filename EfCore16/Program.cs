using C01.BasicSaveWithTracking.Data;
using C01.BasicSaveWithTracking.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EfCore16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseHelper.RecreateCleanDatabase();
            DatabaseHelper.PopulateDatabase();  

            DatabaseHelper.ShowBooks();

            using var Context = new AppDbContext();
            var book=Context.Books.FirstOrDefault();
            Context.Books.Remove(book);
            Context.SaveChanges();
            Console.WriteLine("-----------------------------------------------------");

            DatabaseHelper.ShowBooks();
        }
    }
}