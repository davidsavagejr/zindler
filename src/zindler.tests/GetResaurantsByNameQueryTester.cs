using System;
using System.Linq;
using NUnit.Framework;
using zindler.web.Core.Queries;
using Should;

namespace zindler.tests
{
	[TestFixture]
	public class GetResaurantsByNameQueryTester : DataTestBase
	{
		[Test, Ignore()]
		public void Should_return_list_of_restaurants()
		{
			var query = new GetRestaurantsByNameQuery();
			var results = query.Execute("chipotle");

			Assert.That(results.Count, Is.GreaterThan(5));
		}
		[Test, Ignore()]
		public void Should_return_address_for_restaurant()
		{
			var query = new GetRestaurantsByNameQuery();
			var results = query.Execute("chipotle");

			var result = results.First();

			result.Address.ShouldNotBeNull();
			result.Address.StreetLine1.ShouldNotBeEmpty();
			result.Address.City.ShouldNotBeEmpty();
			result.Address.State.ShouldNotBeEmpty();
			result.Address.PostalCode.ShouldNotBeEmpty();
		}
		[Test, Ignore()]
		public void Should_only_return_items_with_search_in_the_name()
		{
			var query = new GetRestaurantsByNameQuery();
			var results = query.Execute("chipotle");

			results.All(x => x.Name.StartsWith("CHIPOTLE", StringComparison.CurrentCultureIgnoreCase)).ShouldBeTrue();
		}
	}
}
