using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore8.Entities
{
	public class Student
	{
		public int Id { get; set; }
		public string? Name { get; set; }

		public ICollection<Section> Sections { get; set; } = new List<Section>();

	}
}

