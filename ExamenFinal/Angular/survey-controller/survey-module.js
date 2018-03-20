(function () {

    var module = angular.module("surveyApp");

    var surveyController = function ($scope, surveyAPI) {

        surveyAPI.getSurveys().then( function(data){
            $scope.surveys = data;
        })

    }; 

    module.controller("surveyController", surveyController);

}());




