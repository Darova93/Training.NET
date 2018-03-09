//'use strict';
var app = angular.module('AcademyApp', [])
app.controller('UserController', function UserController($http) {

    this.users = [{
        is: "DRVA",
        fname: "David",
        last_name: "Rodriguez",
        second_last_name: "Vazquez",
        hour: "10-10-2018T17:00:00",
        calification: "10"
    }]

    this.SendUser = function () {
        var data = {
            is: "DRVA",
            first_name: "David",
            last_name: "Rodriguez",
            second_last_name: "Vazquez",
            hour: "10-10-2018T17:00:00",
            calification: "10"
        };

        var jsondata = JSON.stringify(data);
        var baseUrl = 'http://10.0.16.28:3000/users';

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

});
