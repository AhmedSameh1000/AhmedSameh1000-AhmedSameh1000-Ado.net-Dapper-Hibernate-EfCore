using C01.SplitQuery.QueryData.Data;
using C01.SplitQuery.QueryData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EfCore11
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ReadLine();
        }
        private static IEnumerable<string> GetDays(Schedule schedules)
        {
            var res=new List<string>();

            if (schedules.SAT)
                res.Add(nameof(schedules.SAT));


            if (schedules.SUN)
                res.Add(nameof(schedules.SUN));


            if (schedules.MON)
                res.Add(nameof(schedules.MON));


            if (schedules.TUE)
                res.Add(nameof(schedules.TUE));


            if (schedules.WED)
                res.Add(nameof(schedules.WED));


            if (schedules.THU)
                res.Add(nameof(schedules.THU));


            if (schedules.FRI)
                res.Add(nameof(schedules.FRI));

            return res;

        }
        public static void Methode1()
        {
            using (var context = new AppDbContext())
            {
                var Courses = context.Courses.AsNoTracking().
                   Select(c => new
                   {

                       CourseId = c.Id,
                       CourseName = c.CourseName,
                       Houres = c.HoursToComplete,
                       Section = c.Sections.Select(s => new
                       {
                           SectionId = s.Id,
                           SectionName = s.SectionName,
                           DateRange = s.DateRange.ToString(),
                           TimeSlote = s.TimeSlot.ToString(),
                       }),
                       Reviews = c.Reviews.Select(R => new
                       {
                           FeedBack = R.Feedback,
                           CreatedAt = R.CreatedAt,
                       })
                   })
                    .ToList();
            };
        }
        public static void Methode2()
        {
            //Inner Join
            using (var context = new AppDbContext())
            {
                var result = (from c in context.Courses
                              join s in context.Sections
                              on c.Id equals s.CourseId
                              select new
                              {
                                  c.CourseName,
                                  s.SectionName
                              }).ToList();


                var result2 = context.Courses.Join(context.Sections, c => c.Id, s => s.CourseId, (c, s) => new
                {
                    CourseName = c.CourseName,
                    SectionName = s.SectionName
                }).ToList();
            };
        }
        public static void Methode3()
        {
            //join left Join 
            using (var context = new AppDbContext())
            {
                var result = (from O in context.Offices
                              join I in context.Instructors
                              on O.Id equals I.OfficeId
                              select new
                              {
                                  Oficess = O.OfficeName,
                                  Instractors = I != null ? (I.FName + " " + I.LName) : "Empty"
                              }).ToList();

                Console.WriteLine("_------------------");
                var result2 = (from O in context.Offices
                               join I in context.Instructors
                               on O.Id equals I.OfficeId into instructorGroup
                               from instructor in instructorGroup.DefaultIfEmpty()
                               select new
                               {
                                   Offices = O.OfficeName,
                                   Instructors = instructor != null ? (instructor.FName + " " + instructor.LName) : "Empty"
                               }).ToList();

                Console.WriteLine("_------------------");

                var result3 = (from O in context.Offices
                               join I in context.Instructors
                               on O.Id equals I.OfficeId into instructorGroup
                               from instructor in instructorGroup.DefaultIfEmpty()
                               select new
                               {
                                   Offices = O.OfficeName,
                                   Instructor = instructor != null ? (instructor.FName + " " + instructor.LName) : "Empty"
                               }).ToList();






                foreach (var item in result3)
                {
                    Console.WriteLine($"{item.Offices} || {item.Instructor}");
                }
            };

        }

        public static void Methode4()
        {
            //join left Join 
            using (var context = new AppDbContext())
            {
                var result = context.Offices.GroupJoin
                    (context.Instructors,
                    O => O.Id,
                    I => I.OfficeId,
                    (O, I) => new { O, I })
                    .SelectMany(
                    ov => ov.I.DefaultIfEmpty(),
                    (ov, Instractor) => new
                    {

                        OfficeName = ov.O.OfficeName,
                        Instractorname = Instractor != null ? (Instractor.FName + " " + Instractor.LName) : "Empty"
                    }
                    ).ToList();





                foreach (var item in result)
                {
                    Console.WriteLine($"{item.OfficeName} || {item.Instractorname}");
                }
            };
        }
        public static void Meethode5()
        {
            //CrossJoin 
            using (var context = new AppDbContext())
            {
                var CrossJoin = from s in context.Sections
                                from I in context.Instructors
                                select new
                                {
                                    s.SectionName,
                                    I.FName
                                };

                Console.WriteLine(CrossJoin.Count());
            };
        }

        public static void Methode6()
        {
            //select many
            using (var context = new AppDbContext())
            {
                var frontEndParticepent =
                    (
                    from c in context.Courses
                    where c.CourseName.Contains("Frontend")
                    from s in c.Sections
                    from p in s.Participants
                    select new
                    {
                        StudentName = p.FullName,
                    });


                var frontEndParticepent2 =
                    context.Courses.
                    Where(c => c.CourseName.Contains("Frontend"))
                    .SelectMany(c => c.Sections)
                    .SelectMany(c => c.Participants)
                    .Select(c => c.FullName).ToList();


                foreach (var name in frontEndParticepent)
                {
                    Console.WriteLine(name);
                }
            };
        }
        public static void Methode7()
        {
            //Grouping 

            using (var context = new AppDbContext())
            {
                var InstractorSection =
                    (from s in context.Sections
                     group s by s.Instructor
                     into g
                     select new
                     {
                         Key = g.Key,
                         Sections = g.ToList()
                     }).ToList();

                var InstractorSection1 =
                    context.Sections.GroupBy(c => c.Instructor)
                    .Select(c => new
                    {
                        Key = c.Key,
                        TotalSections = c.Count()
                    }).ToList();



                foreach (var Data in InstractorSection1)
                {
                    Console.WriteLine($"###{Data.Key.FName}###{Data.TotalSections}");
                }

            };

        }
        public static void Methode8()
        {
            //paging
            using (var context = new AppDbContext())
            {
                var pageNum = 1;
                var pageSize = 10;
                var TotalSection = context.Sections.Count();
                var TotalPages = (int)Math.Ceiling((double)TotalSection / pageSize);
                var Result =
                    context.Sections.AsNoTracking()
                    .Include(c => c.Course)
                    .Include(c => c.Instructor)
                    .Include(c => c.Schedule)
                    .Select(res => new
                    {
                        Course = res.Course.CourseName,
                        Instractor = res.Instructor.FName + " " + res.Instructor.LName,
                        DateRange = res.DateRange.ToString(),
                        TimeSlot = res.TimeSlot.ToString(),
                        Days = string.Join("|", GetDays(res.Schedule))
                    });
                int i = 1;
                while (pageNum <= TotalPages)
                {
                    Console.Clear();
                    var pageResult = Result.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
                    foreach (var Data in pageResult)
                    {

                        Console.WriteLine(
                            $"{i++} -- " +
                            $"{Data.Course}" +
                            $"{Data.Instractor} " +
                            $"{Data.DateRange} " +
                            $"{Data.TimeSlot} " +
                            $"{Data.Days} ");
                    }
                    Console.ReadKey();
                    ++pageNum;

                }
            };
        }
    }
}