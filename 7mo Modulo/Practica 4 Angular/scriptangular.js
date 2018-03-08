var app = angular.module('surveyApp', [])

app.controller('SurveyController', function SurveyController() {
    this.preguntas = [
    ];

    this.crearPregunta = function () {
        this.preguntas.push({
            name: this.newQuestion,
            options: []
        });
        this.newQuestion = "";
    }

    this.crearOpcion = function (index) {
        this.preguntas[index].options.push({
            name: this.newOption
        });
        this.newOption = "";
    }

    this.borrarOpcion = function (position, index) {
        this.preguntas[position].options.splice(index, 1)
    }

    this.borrarPregunta = function (index) {
        this.preguntas.splice(index, 1)
    }

});
