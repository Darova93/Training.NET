(function () {

    var module = angular.module("surveyApp");

    var answerController = function ($scope, surveyAPI, $routeParams) {

        surveyAPI.getQuestions($routeParams.surveyid).then(function (data) {
            var questions = data;
            var surveyform = [];
            var count = 0;
            questions.forEach(question => {
                
                var answer = {
                    SurveyId: $routeParams.surveyid,
                    QuestionId: question.Id,
                    Answer: "",
                    Guest: "David"
                };

                surveyform.push(answer);

                switch (question.QuestionTypeId) {
                    case 1:
                        question.input = "text";
                        question.model = "surveyform["+ count +"].OpenText";
                        question.count = count;
                        question.Options.push("");
                        break;
                    case 2:
                        question.input = "radio";
                        question.model = "surveyform["+ count +"].OptionId";
                        question.count = count;
                        break;
                    case 3:
                        question.input = "checkbox";
                        question.model = "surveyform["+ count +"].OptionId";
                        question.count = count;
                        break;
                }
                count += 1;
            });

            $scope.surveyform = surveyform;
            $scope.questions = questions;
        })

        

    };

    // var AnswerSurvey = function () {
    //     surveyform.forEach(answer => {
    //         if(angular.isNumber(answer.Answer)){
    //             var tosend ={
    //                 SurveyId = answer.SurveyId,
    //                 QuestionId = answer.QuestionId,
    //                 Guest = answer.Guest,
    //                 OptionId = answer.Answer
    //             }   
    //         }
    //         else{
    //             var tosend ={
    //                 SurveyId = answer.SurveyId,
    //                 QuestionId = answer.QuestionId,
    //                 Guest = answer.Guest,
    //                 OpenText = answer.Answer
    //             }
    //         }
            
    //         surveyAPI.PostAnswer(tosend);
    //     });   

    //     return ("ok");
    // }

    module.controller("answerController", answerController);

}());




