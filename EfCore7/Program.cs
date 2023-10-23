using EfCore7.Data;
using EfCore7.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore7
{
	public class Program
	{
		static void Main(string[] args)
		{
			var Orders = new AppDbContext();
			var data = Orders.Set<OrderBill>()
				.FromSqlInterpolated($"select * from GetOrderBill({1})");

			var data2 = Orders.OrderWithDetailsView;



			foreach (var item in data2)
			{
				Console.WriteLine(item.CustomerEmail);
			}
		}
	}
}