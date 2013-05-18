using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using AutoMapper;
using YelpSharp;
using YelpSharp.Data.Options;
using zindler.data;
using zindler.web.Models;

namespace zindler.web.Core.Queries
{
	public class GetRestaurantsByNameQuery
	{
		public IList<Restaurant> Execute(string name)
		{
			var accessToken = ConfigurationManager.AppSettings["Yelp.AccessToken"];
			var accessTokenSecret = ConfigurationManager.AppSettings["Yelp.AccessTokenSecret"];
			var consumerKey = ConfigurationManager.AppSettings["Yelp.ConsumerKey"];
			var consumerSecret = ConfigurationManager.AppSettings["Yelp.ConsumerSecret"];

			var yelp = new Yelp(new Options { AccessToken = accessToken, AccessTokenSecret = accessTokenSecret, ConsumerKey = consumerKey, ConsumerSecret = consumerSecret });
		    var options = new SearchOptions
		        {
		            GeneralOptions = new GeneralOptions {category_filter = "food", term = name, radius_filter = 40000, offset = 0},
		            LocationOptions = new LocationOptions {location = "houston, tx"}
		        };
			var results = yelp.Search(options).Result;
			var restaurants = results.businesses.Select(Mapper.Map<Restaurant>).ToList();

            while (results.total >= restaurants.Count)
            {
                options.GeneralOptions.offset += 19;
                results = yelp.Search(options).Result;
                restaurants.AddRange(results.businesses.Select(Mapper.Map<Restaurant>).ToList());
            }

		    foreach (var restaurant in restaurants)
		    {
		        if (restaurant.Address.StreetLine1 != null)
		        {
                    var inspections = InspectionData.Records.Where(i => restaurant.Address.StreetLine1.ToLower().StartsWith(string.Format("{0} {1}", i.StNum, i.StName).ToLower())).ToList();
                    if (inspections.Any())
                        restaurant.Violations = inspections.Select(Mapper.Map<Violation>).ToList();
		        }
		        
		    }
			return restaurants.Where(x => x.Name.StartsWith(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
		}
	}
}