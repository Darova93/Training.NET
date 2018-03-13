(function () {

    var app = angular.module("ToDoList", ["ngRoute"]);

    app.config(function ($routeProvider) {
        $routeProvider
            .when("/tasks", {
                templateUrl: "./item-list.html",
                controller: "itemController"
            })
            .when("/tasks/new", {
                templateUrl: "./item-new.html",
                controller: "itemController",
                controllerAs: 'ctrl'
            })
            .when("/tasks/:taskid", {
                templateUrl: "./item-description.html",
                controller: "itemController"
            })
            .when("/tags", {
                templateUrl: "./tag-list.html",
                controller: "tagController"
            })
            .when("/tags/:tagid", {
                templateUrl: "./tag-description.html",
                controller: "tagController"
            })
        .otherwise({redirectTo:"/tasks"});

    });

}());