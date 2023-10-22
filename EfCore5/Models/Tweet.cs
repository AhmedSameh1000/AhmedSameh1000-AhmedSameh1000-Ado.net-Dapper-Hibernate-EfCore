using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace EfCore5.Models
{
	public class Tweet
	{
		public int TweetId { get; set; }	
		public string TweetText { get; set; }
		public int UserId { get; set; }
		public DateTime CreatedAt { get; set;}

		public override string ToString()
		{
			return $"[{TweetId}] ({TweetText}) => {UserId} => {CreatedAt}";
		}
	} 
}


