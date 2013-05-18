define(['durandal/system', 'durandal/plugins/router'],
    function (system, router) {
    	var data = [{ name: 'Chipotle', address: '1022 Main street' }, { name: 'Brendas Mexican', address: '7763 Westheimer rd.' }];
    	return {
    		router: router,
    		activate: function () {
    			system.log("Search View Activated!!");
    		},
    		showResults: function (text) {
    			system.log('restaurant: ' + typeof (text));
    			this.restaurants(data);
    		},
    		restaurants: ko.observableArray([])
    	};
    });