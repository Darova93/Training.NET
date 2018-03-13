(function () {

    var todolistapp = function ($http) {

        var getTasks = function () {
            return $http.get("http://localhost:3000/DRVA/tasks")
                .then(function (response) {
                    console.log(response.data);
                    return response.data;
                });
        };

        var getTask = function (id) {
            return $http.get("http://localhost:3000/DRVA/tasks/" + id)
                .then(function (response) {
                    return response.data;
                });
        };

        var getTaskTags = function (id) {
            return $http.get("http://localhost:3000/DRVA/tags/"+id)
                .then(function (response) {
                    return response.data;
                })
        };

        var createTask = function (data) {

            var jsondata = JSON.stringify(data);
            var baseUrl = "http://localhost:3000/DRVA/tasks/";
    
            var config = {
                method: "POST",
                url: baseUrl,
                data: jsondata,
                isArray: true,
                headers: {
                    'Content-Type': 'application/json; charset=utf-8'
                }
            };
            return $http(config);
        }

        return {
            getTasks: getTasks,
            getTask: getTask,
            getTaskTags: getTaskTags,
            createTask: createTask
        };
    };

    var module = angular.module("ToDoList");
    module.factory("todolistapp", ["$http", todolistapp]);

}());