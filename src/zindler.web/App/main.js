require.config({
	paths: { "text": "durandal/amd/text" },
	urlArgs: 'bust=' + (new Date()).getTime() // for automatic cache busting during development
});

define(['durandal/system',
        'durandal/app',
        'durandal/viewLocator',
        'routerConfiguration'],
    function (system, app, viewLocator) {

    	//>>excludeStart("build", true)
    	system.debug(true);
    	//>>excludeEnd("build")

    	app.start().then(function () {
    		//Replace 'viewmodels' in the moduleId with 'views' to locate the view.
    		//Look for partial views in a 'views' folder in the root.
    		viewLocator.useConvention();

    		// configure the app
    		app.title = "Zindler";
    		app.adaptToDevice();
    		
    		app.setRoot("viewmodels/shell");
	});
});