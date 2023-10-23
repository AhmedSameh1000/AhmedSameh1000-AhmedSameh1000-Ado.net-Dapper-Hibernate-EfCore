using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore7.Models
{
	public class OrderBill
	{
		public DateTime OrderDate { get; set; }
		public string ProductName { get; set; }
	
		public decimal UnitPrice { get; set; }
	
		public int Quantity { get; set; }
		public decimal SubTotal { get; set; }


		public override string ToString()
		{
			return $"{OrderDate} {ProductName}";
		}
	}
}
/*
 #mappint to Function
			var OrderBill = new AppDbContext();
			var data = OrderBill.Set<OrderBill>()
				.FromSqlInterpolated($"select * from GetOrderBill({1})");
 
 */