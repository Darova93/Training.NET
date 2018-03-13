(function () {

    var module = angular.module("ToDoList");

    var itemController = function ($scope, todolistapp, $routeParams) {

        todolistapp.getTasks().then(function (data) {
            $scope.tasks = data;
        });

        $scope.taskid = $routeParams.taskid;
        if ($scope.taskid) {
            todolistapp.getTask($scope.taskid).then(function (data) {
                $scope.task = data;
            });
        }

        var getTags = function (data) {
            $scope.task = data;
            todolistapp.getTaskTags($scope.task.id).then(function (response) {
                this.tasktags = response.data;
            });
        };

        this.createTask = function () {

            var data = {
                name: this.taskdescription,
                description: this.taskname,
                isDone: "false"
            }

            todolistapp.createTask(data).then(function (response) {
                console.log(response);
            })

        };

    };

    module.controller("itemController", ["$scope", "todolistapp", "$routeParams", itemController]);

}());




