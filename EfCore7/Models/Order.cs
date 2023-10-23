namespace EfCore7.Models
{
	public class Order
	{
		public int Id { get; set; }
		public string CustomerEmail { get; set; }
		public DateTime OrderDate { get; set; }
		public IEnumerable<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
	}
}
