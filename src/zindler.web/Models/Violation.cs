using System;

namespace zindler.web.Models
{
	public class Violation
	{
		public int Id { get; set; }
		public DateTime DateOfViolation { get; set; }
		public string Description { get; set; }
	}
}