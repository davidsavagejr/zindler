using System;

namespace zindler.web.Models
{
	public class YelpReview
	{
		public double Rating { get; set; }
		public DateTime DateOfReview { get; set; }
		public string Excerpt { get; set; }
		public string Url { get; set; }
	}
}