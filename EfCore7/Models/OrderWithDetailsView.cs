using Microsoft.EntityFrameworkCore;

namespace EfCore7.Models
{
	public class OrderWithDetailsView
	{
		public DateTime OrderDate { get; set; }
		public string CustomerEmail { get; set; }
		public string ProductName { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
 	}

}
/*
 #mapping to view 
1-if you use Convension Name must Be the table Same name  
else you need to set Configuration 
			modelBuilder.Entity<OrderWithDetailsView>()
				.ToView("OrderWithDetailsView")
				.HasNoKey();
 */
