define(['durandal/system', 'durandal/plugins/router'],
    function (system, router) {
    	var data = [{ Name: 'Shipley Donuts', RatingImage:'', AverageRating: 3, Photo: 'http://s3-media2.ak.yelpcdn.com/bphoto/6YQ5AeIIAkOCWpQV6_p2Fg/ms.jpg', Address: { StreetLine1: '3410 Ella Blvd' } },
    		{ Name: 'Shipley Donuts', RatingImage: '', AverageRating: 2, Photo: 'http://s3-media2.ak.yelpcdn.com/bphoto/S8QwjqXI4W6GODUjpQu8QQ/ms.jpg', Address: { StreetLine1: '1203 Richmond Ave' } }
    	];
	    var viewModel = {
    		router: router,
    		activate: function () {
    			system.log("Search View Activated!!");
    			setTimeout(function() {
    				$("#searchBox")[0].focus();
    			}, 500);
    		},
    		restaurants: ko.observableArray([]),
    		searchText: ko.observable("")
    	};

    	$(document).on('keyup', '#searchBox', function () {
    		var name = $(this).val();
    		system.log(name);
    		$.get('/api/search?name=' + name).done(function (results) {
    			viewModel.restaurants(results);
    		});
    	});

    	return viewModel;
    });