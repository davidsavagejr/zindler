define(['durandal/system', 'durandal/plugins/router'],
    function (system, router) {
    	return {
    		router: router,
    		activate: function () {
    			system.log("Search View Activated!!");
    		}
    	};
    });