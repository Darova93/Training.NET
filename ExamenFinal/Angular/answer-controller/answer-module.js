(function () {

    var module = angular.module("surveyApp");

    var answerController = function ($scope, surveyAPI, $routeParams) {

        surveyAPI.getQuestions($routeParams.surveyid).then(function (data) {
            var questions = data;
            questions.forEach(question => {
                switch (question.QuestionTypeId) {
                    case 1:
                        question.input = "text";
                        question.Options.push("Type your answer here");
                        break;
                    case 2:
                        question.input = "radio";
                        break;
                    case 3:
                        question.input = "checkbox";
                        break;
                }
            });
            $scope.questions = questions;
        })

        var surveyform = {};
        console.log(surveyform);

    };

    module.controller("answerController", answerController);

}());




