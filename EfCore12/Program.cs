using C01.SplitQuery.QueryData.Data;
using EfCore12.PROCEDUREModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EfCore12
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }


        public static void Methode1()
        {
            //FromSqlRaw -- FromSql -- FromSqlInterpolated

            var Context = new AppDbContext();

            //var Courses1 = Context.Courses.FromSql($"select * from courses");
            //var Courses2 = Context.Courses.FromSqlInterpolated($"select * from courses");
            //var Courses3= Context.Courses.FromSqlRaw("select * from courses");
            //var Course = Context.Courses.FromSqlInterpolated($"select * from courses where id ={1}").FirstOrDefault();
            //var Course = Context.Courses.FromSql($"select * from courses where id ={1}").FirstOrDefault();


            //var CourseIdParameter = new SqlParameter()
            //{
            //    ParameterName = "@Data",
            //    Value = 1,
            //    SourceColumn = "Courseid" 
            //};
            var parameter = new SqlParameter("@Data", 1);

            var Course = Context.Courses.FromSqlRaw("select * from courses where id =@Data", parameter).FirstOrDefault();
            Console.WriteLine("----------");
            Console.WriteLine(Course.CourseName);
        }

        public static  void Mehtode2() 
        {
            using (var Context = new AppDbContext())
            {
                var Id = new SqlParameter("@SectionId", 2);

                var Result = Context.Set<SectionDetails>().FromSql($"Exec [dbo].[sp_GetSectionDetails] {Id} ").ToList();

                Console.WriteLine(Result.FirstOrDefault());

            };
        }

    }
}