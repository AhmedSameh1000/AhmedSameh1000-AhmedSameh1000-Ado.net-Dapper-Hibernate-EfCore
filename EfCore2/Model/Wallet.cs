using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore1.Model
{
	public class Wallet
	{
		public int Id { get; set; }
		public string? Holder { get; set; }
		public decimal? Balance { get; set; }

		public override string ToString()
		{
			return $"[{Id}] {Holder} ({Balance:C})";
		}
	}

	
}
