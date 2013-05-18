using System.Collections.Generic;
using System.Diagnostics;

namespace zindler.web.Models
{
    [DebuggerDisplay("{Name}, {Address}")]
	public class Restaurant
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public Address Address { get; set; }

		public IList<Violation> Violations { get; set; }
	
		public string Phone { get; set; }
		public string Photo { get; set; }
		public double AverageRating { get; set; }
		public string RatingImage { get; set; }
		public IList<YelpReview> Reviews { get; set; } 
	}
}