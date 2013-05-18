define(['durandal/system', 'durandal/plugins/router'],
    function (system, router) {
    	var data = [{ name: 'Chipotle', address: '1022 Main street' },
    		{ name: 'Brendas Mexican', address: '7763 Westheimer rd.' }];

    	return {
    		router: router,
    		activate: function () {
    			system.log("Search View Activated!!");
    		},
    		showResults: function () {
    			var self = this;
    			var name = this.searchText();
    			system.log(name);

    			$.get('/api/search?name=' + name).done(function(results) {
    				self.restaurants(results);
    			});
    		},
    		restaurants: ko.observableArray([]),
    		searchText: ko.observable("")
    	};
    });