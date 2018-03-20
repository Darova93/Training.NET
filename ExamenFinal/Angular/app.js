(function () {

    var app = angular.module("surveyApp", ["ngRoute"]);

    app.config(function ($routeProvider) {
        
        $routeProvider
            .when("/survey", {
                templateUrl: "./survey-controller/survey-module-template.html",
                controller: "surveyController"
            })
            .when("/survey/:surveyid", {
                templateUrl: "./answer-controller/answer-module.template.html",
                controller: "answerController",
                controllerAs: "ctrl"
            })
        .otherwise({redirectTo:"/survey"});

    });

}());