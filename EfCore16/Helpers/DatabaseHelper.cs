using C01.BasicSaveWithTracking.Data;
using C01.BasicSaveWithTracking.Entities;
using Microsoft.EntityFrameworkCore;

namespace C01.BasicSaveWithTracking.Helpers
{
    public static class DatabaseHelper
    {
        public static void RecreateCleanDatabase()
        {
            using var context = new AppDbContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public static void PopulateDatabase()
        {
            using (var context = new AppDbContext())
            {
                context.AddRange(
                     new Book
                     {
                         Id = 1,
                         Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software",
                         Auther="Ahmed"
                     },

                      new Book
                      {
                          Id = 2,
                          Title = "Domain-Driven Design Reference: Definitions and Pattern Summaries",
                          Auther = "Ali"
                      },
                      new Book
                      {
                          Id = 3,
                          Title = "Book #3",
                          Auther = "Sara"
                      },
                      new Book
                      {
                          Id = 4,
                          Title = "Book #4",
                          Auther = "Sameh"
                      },
                     new Book
                     {
                         Id = 5,
                         Title = "Book #5",
                         Auther = "mohamed"
                     },
                     new Book
                     {
                         Id = 6,
                         Title = "Book #6",
                         Auther = "Adel"
                     },
                     new Book
                     {
                         Id = 7,
                         Title = "Book #7",
                         Auther = "Hatem"
                     },
                     new Book
                     {
                         Id = 8,
                         Title = "Book #8",
                         Auther = "Aza"
                     },
                     new Book
                     {
                         Id = 9,
                         Title = "Book #9",
                         Auther = "Salem"
                     }

                    );
                   
                   



                context.SaveChanges();
            }
        }

        public static void ShowBooks()
        {
            var Context=new AppDbContext(); 
            foreach (var item in Context.Books)
            {
                Console.WriteLine(item);
            }
        }
     
    }
}
