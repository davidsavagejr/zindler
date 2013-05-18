define(['durandal/system', 'durandal/plugins/router'],
    function (system, router) {
    	var viewModel = {
    		router: router,
    		activate: function () {
    			system.log("Search View Activated!!");
    		},
    		showResults: function () {
    			var self = this;
    			var name = this.searchText();
    			system.log(name);

    			$.get('/api/search?name=' + name).done(function (results) {
    				self.restaurants(results);
    			});
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