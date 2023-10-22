using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore5.Models
{
	public class User
	{
		public int UserId { get; set; }
		public string Username { get; set; }
		public override string ToString()
		{
			return $"[{UserId}] ({Username})";
		}
	}
}
