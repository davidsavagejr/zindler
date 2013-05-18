using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Hosting;
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
		    if (string.IsNullOrEmpty(name))
		        return new List<Restaurant>(); 

			var accessToken = ConfigurationManager.AppSettings["Yelp.AccessToken"];
			var accessTokenSecret = ConfigurationManager.AppSettings["Yelp.AccessTokenSecret"];
			var consumerKey = ConfigurationManager.AppSettings["Yelp.ConsumerKey"];
			var consumerSecret = ConfigurationManager.AppSettings["Yelp.ConsumerSecret"];

			var yelp = new Yelp(new Options { AccessToken = accessToken, AccessTokenSecret = accessTokenSecret, ConsumerKey = consumerKey, ConsumerSecret = consumerSecret });
			var results = yelp.Search(new SearchOptions
		        {
		            GeneralOptions = new GeneralOptions {category_filter = "food", term = name, radius_filter = 40000},
		            LocationOptions = new LocationOptions {location = "houston, tx"}
		        }).Result;

			var restaurants = results.businesses.Select(Mapper.Map<Restaurant>).ToList();

		    foreach (var restaurant in restaurants)
		    {
		        if (restaurant.Address.StreetLine1 != null)
		        {

                    var inspections = InspectionData.GetRecords(HostingEnvironment.MapPath("~/App_Data/inspection-data.txt")).Where(i => restaurant.Address.StreetLine1.ToLower().StartsWith(string.Format("{0} {1}", i.StNum, i.StName).ToLower())).ToList();
                    if (inspections.Any())
                        restaurant.Violations = inspections.Select(Mapper.Map<Violation>).ToList();
		        }
		        
		    }
			return restaurants.Where(x => x.Name.StartsWith(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
		}
	}
}