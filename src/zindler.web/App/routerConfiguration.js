define(['durandal/plugins/router'], function (router) {
	router.useConvention();

	router.mapNav("/", "viewmodels/search");

	router.mapNav("search");

	router.mapNav("about");
	
	router.mapNav("search/:name", "viewmodels/searchResult", "Search Results");
	router.mapNav("details/:name", "viewmodels/restaurantDetail", "Restaurant Detail");
});