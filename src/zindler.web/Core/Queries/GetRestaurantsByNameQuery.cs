using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using AutoMapper;
using YelpSharp;
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
			var results = yelp.Search(name, "houston, tx").Result;

			return results.businesses.Select(Mapper.Map<Restaurant>).ToList();
		}
	}
}