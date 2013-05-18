using NUnit.Framework;
using zindler.web.Core.Queries;
using Should;

namespace zindler.tests
{
	[TestFixture]
	public class GetResaurantsByNameQueryTester : DataTestBase
	{
		[Test]
		public void Should_return_list_of_restaurants()
		{
			var query = new GetRestaurantsByNameQuery();
			var results = query.Execute("chipotle");

			Assert.That(results.Count, Is.GreaterThan(5));
		}
	}
}
