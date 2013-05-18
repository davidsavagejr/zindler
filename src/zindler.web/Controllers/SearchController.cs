using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using zindler.web.Core.Queries;
using zindler.web.Models;

namespace zindler.web.Controllers
{
	 public class SearchController : ApiController
	 {
		 public IEnumerable<Restaurant> Get(string name)
		 {
			 var query = new GetRestaurantsByNameQuery();
			 return query.Execute(name);
		 } 

         public IEnumerable<string> Config()
         {
             return new List<string>() { ConfigurationManager.AppSettings["Yelp.AccessToken"] == "TEMP" ? "AccessToken Configured" : "NOT CONFIGURED!!"};
         }
	 }
}
