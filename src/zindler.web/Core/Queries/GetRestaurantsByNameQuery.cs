﻿using System;
using System.Collections.Generic;
using System.Linq;
using YelpSharp;
using zindler.web.Models;

namespace zindler.web.Core.Queries
{
	public class GetRestaurantsByNameQuery
	{
		public IList<Restaurant> Execute(string name)
		{
		    var yelp = new Yelp(new Options());
			var results = yelp.Search(name, "Houston");

			return results.Result.businesses.Select(x => new Restaurant
				                                             {
					                                             Address = new Address
						                                                       {
							                                                       City = x.location.city,
							                                                       PostalCode = x.location.postal_code,
							                                                       State = x.location.state_code,
							                                                       StreetLine1 = x.location.address[0],
						                                                       },
					                                             AverageRating = x.rating,
					                                             Id = x.id,
					                                             Name = x.name,
					                                             Phone = x.display_phone,
					                                             Photo = x.image_url,
					                                             Reviews =
						                                             x.reviews.Select(
							                                             review =>
							                                             new Review
								                                             {
									                                             Excerpt = review.excerpt,
									                                             Rating = review.rating,
									                                             DateOfReview = DateTime.FromOADate(review.time_created)
								                                             }).ToList(),
					                                             Violations = new List<Violation>()
				                                             }).ToList();
		}
	}
}