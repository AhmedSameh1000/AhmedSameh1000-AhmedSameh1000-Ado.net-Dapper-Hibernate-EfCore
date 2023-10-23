using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore7.Models
{
	public class Product
	{
        public Product()
        {
			SnapShot=new SnapShot();
		}
        public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal UnitPrice { get; set; }
		public SnapShot SnapShot { get; set; }
	}
}
