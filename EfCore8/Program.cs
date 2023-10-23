using EfCore8.Data;
using EfCore8.Migrations;
using Microsoft.EntityFrameworkCore;

namespace EfCore8
{
	internal static class Program
	{
		static void Main(string[] args)
		{
			var context = new AppDbContext();

			var data = context.Sections.Include(c=>c.Instructor)
				.Include(c=>c.Course).Include(c=>c.Students)
				.Include(c=>c.Schedules);

			foreach (var c in data)
			{
				Console.WriteLine($"{c.Id} | {c.SectionName} " +
					$"| " +
					$"{c.Instructor.Name} | {c.Course.CourseName}");
				c.Schedules.Print();

				Console.WriteLine("\n\n");
			}

		}
		public static void Print<T>(this IEnumerable<T> Source)
		{
			foreach (var item in Source)
			{
				Console.WriteLine(item);
			}

		}
	}
}