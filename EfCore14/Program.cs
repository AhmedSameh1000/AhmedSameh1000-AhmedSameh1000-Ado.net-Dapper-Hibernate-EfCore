using C03.CascadeDelete.Helpers;
using C01.SqlQuery.Data;
using Microsoft.EntityFrameworkCore;

namespace EfCore14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SeveringRelationship_PrincipalAuthor_ClearDependents_Dependent_Book_FK_Optional();
        }

        public static void DeletePrincipalAuthor_With_Dependent_Book_FK_Required()
        {
            Console.WriteLine($">>>> Sample: {nameof(DeletePrincipalAuthor_With_Dependent_Book_FK_Required)}");
            Console.WriteLine();

            DatabaseHelper.RecreateCleanDatabase();
            DatabaseHelper.PopulateDatabase();

            using (var context = new AppDbContext())
            {
                var author = context.Authors.First();

                context.Authors.Remove(author);

                context.SaveChanges();
            }

            Console.ReadKey();
        }

        public static void DeletePrincipalAuthor_With_Dependent_Book_FK_Optional()
        {
            Console.WriteLine($">>>> Sample: {nameof(DeletePrincipalAuthor_With_Dependent_Book_FK_Optional)}");
            Console.WriteLine();

            DatabaseHelper.RecreateCleanDatabase();
            DatabaseHelper.PopulateDatabase();

            using (var context = new AppDbContext())
            {
                var author = context.AuthorV2s.First();

                context.AuthorV2s.Remove(author);

                context.SaveChanges();
            }

            Console.ReadKey();
        }

        public static void SeveringRelationship_DependentBook_SetPrincipal_Null_FK_Optional()
        {
            Console.WriteLine($">>>> Sample: {nameof(SeveringRelationship_DependentBook_SetPrincipal_Null_FK_Optional)}");
            Console.WriteLine();

            DatabaseHelper.RecreateCleanDatabase();
            DatabaseHelper.PopulateDatabase();

            using (var context = new AppDbContext())
            {
                var author = context.AuthorV2s.First();

                author.BookV2s.Clear();

                context.SaveChanges();
            }

            Console.ReadKey();
        }

        public static void SeveringRelationship_PrincipalAuthor_ClearDependents_Dependent_Book_FK_Optional()
        {
            Console.WriteLine($">>>> Sample: {nameof(SeveringRelationship_PrincipalAuthor_ClearDependents_Dependent_Book_FK_Optional)}");
            Console.WriteLine();

            DatabaseHelper.RecreateCleanDatabase();
            DatabaseHelper.PopulateDatabase();

            using (var context = new AppDbContext())
            {
                var author = context.AuthorV2s.Include(x => x.BookV2s).First();

                foreach (var book in author.BookV2s)
                {
                    book.AuthorV2 = null;
                }
                context.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}