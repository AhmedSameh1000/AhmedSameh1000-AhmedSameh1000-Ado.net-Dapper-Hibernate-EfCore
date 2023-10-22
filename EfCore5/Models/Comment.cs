using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore5.Models
{
	public class Comment
	{
		public int CommentId { get; set; }
		public string CommentText { get; set; }
		public int UserId { get; set; }
		public int TweetId { get; set; }
		public DateTime CreatedAt { get; set; }
		public override string ToString()
		{
			return $"[{CommentId}] ({CommentText}) => {UserId} => {TweetId} => {CreatedAt}";
		}
	}
}
