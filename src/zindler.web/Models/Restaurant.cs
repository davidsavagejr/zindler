using System.Collections.Generic;

namespace zindler.web.Models
{
	public class Restaurant
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public Address Address { get; set; }

		public IList<Violation> Violations { get; set; }
	
		public string Phone { get; set; }
		public string Photo { get; set; }
		public double AverageRating { get; set; }
		public IList<Review> Reviews { get; set; } 
	}
}