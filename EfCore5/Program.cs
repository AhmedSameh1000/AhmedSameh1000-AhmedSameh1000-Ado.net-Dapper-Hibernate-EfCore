using EfCore4.Data;

namespace EfCore5
{
	public class Program
	{
		static void Main(string[] args)
		{
			using var Context = new AppDbContext();


			foreach (var item in Context.Users)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("------------------");
			foreach (var item in Context.Tweets)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("------------------");
			foreach (var item in Context.Comments)
			{
				Console.WriteLine(item);
			}
		}
	}
}