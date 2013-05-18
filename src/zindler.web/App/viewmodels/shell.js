define(['durandal/system', 'durandal/plugins/router'],
    function (system, router) {
    	return {
    		router: router,
    		activate: function () {
    			system.log("ShellViewModel Activated!!");

    			return router.activate('search');
    		}
    	};
    });