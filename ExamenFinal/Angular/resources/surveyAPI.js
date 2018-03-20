(function () {

    var surveyAPI = function ($http) {

        var getSurveys = function () {
            return $http.get("http://localhost:64082/guest/survey")
                .then(function (response) {
                    return response.data;
                });
        };

        var getQuestions = function (id) {
            return $http.get("http://localhost:64082/guest/survey/"+id+"/questions")
                .then(function (response) {
                    return response.data;
                });
        };

        var postAnswer = function(data){
    
            var baseUrl = 'http://localhost:64082/guest/survey/'+ data.SurveyId;
            var jsondata = JSON.stringify(data);
    
            var config = {
                method: "POST",
                url: baseUrl,
                data: jsondata,
                headers: {
                    'Content-Type': 'application/json; charset=utf-8'
                }
            };
            return $http(config);
        }

        return {
            getSurveys: getSurveys,
            getQuestions: getQuestions,

        };
    };

    var module = angular.module("surveyApp");
    module.factory("surveyAPI", surveyAPI);

}());