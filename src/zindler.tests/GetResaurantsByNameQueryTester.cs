using System;
using NUnit.Framework;
using zindler.web.Core.Queries;
using Should;

namespace zindler.tests
{
	[TestFixture]
	public class GetResaurantsByNameQueryTester
	{
		[Test]
		public void Should_execute()
		{
			var query = new GetRestaurantsByNameQuery();
			var results = query.Execute("chipotle");

			results.Count.ShouldEqual(3);
		}
	}
}
