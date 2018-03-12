angular.module("taskManager").config(["$locationProvider", "$routeProvider",
    function config($locationProvider, $routeProvider) {
        $locationProvider.hashPrefix('!');

        $routeProvider
            .when('/tasks',{
                template: '<itemListController></itemListController>'
            })
            .otherwise('/tasks');
    }])