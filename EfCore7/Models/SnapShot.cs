using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore7.Models
{
	[NotMapped]
	public class SnapShot
	{
		public DateTime LoadAt=>DateTime.Now;
		public string Version =>Guid.NewGuid().ToString().Substring(0,8);	
	}
}
