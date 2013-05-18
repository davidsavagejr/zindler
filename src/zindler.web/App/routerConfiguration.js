define(['durandal/plugins/router'], function (router) {
	router.useConvention();

	router.mapNav("search");
	
	router.mapNav("search/:name", "viewmodels/searchResult", "Search Results");
	router.mapNav("details/:name", "viewmodels/restaurantDetail", "Restaurant Detail");
});