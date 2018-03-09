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

    this.UpdateUser = function(){
        var data = {
            first_name: "Deivid",
            last_name: "rodrigus",
            second_last_name: "vasqus"
        };

        var jsondata = JSON.stringify(data);
        var baseUrl = 'http://10.0.16.28:3000/users/4';

        var config = {
            method: "PUT",
            url: baseUrl,
            data: jsondata,
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        };
        return $http(config);
    }

    this.DeleteUser = function(){

        var baseUrl = 'http://10.0.16.28:3000/users/5';

        var config = {
            method: "DELETE",
            url: baseUrl,
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        };
        return $http(config);
    }

});
