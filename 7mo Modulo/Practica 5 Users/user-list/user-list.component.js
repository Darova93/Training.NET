//'use strict';
var app = angular.module('AcademyApp', [])
app.controller('UserController', function UserController($http) {

    this.user = [{
        is: "DRVA",
        fname: "David",
        last_name: "Rodriguez",
        second_last_name: "Vazquez",
        hour: "10-10-2018T17:00:00",
        calification: "10"
    }]

    this.SendUser = function () {
        var data = {
            is: this.userIs,
            first_name: this.userFname,
            last_name: this.userLname,
            second_last_name: this.userSlname,
            hour: this.userTime,
            calification: this.userGrade
        };

        var jsondata = JSON.stringify(data);
        var baseUrl = 'http://10.0.16.51:3000/users';
        // var baseUrl = 'http://10.0.16.28:3000/users';

        var config = {
            method: "POST",
            url: baseUrl,
            data: jsondata,
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        };
        return $http(config);
        this.userIs = "",
            this.userFname = "",
            this.userLname = "",
            this.userSlname = "",
            this.userTime = "",
            this.userGrade = ""
    }

    this.UpdateUser = function () {
        var data = {
            first_name: this.userFname,
            last_name: this.userLname,
            second_last_name: this.userSlname
        };

        var jsondata = JSON.stringify(data);
        var baseUrl = 'http://10.0.16.51:3000/users' + this.updateID;
        // var baseUrl = 'http://10.0.16.28:3000/users/' + this.updateID;

        var config = {
            method: "PUT",
            url: baseUrl,
            data: jsondata,
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        };
        return $http(config);
        this.updateID = "",
            this.userIs = "",
            this.userFname = "",
            this.userLname = "",
            this.userSlname = "",
            this.userTime = "",
            this.userGrade = ""
    }

    this.DeleteUser = function () {

        var baseUrl = 'http://10.0.16.51:3000/users' + this.deleteID;
        // var baseUrl = 'http://10.0.16.28:3000/users/' + this.deleteID;

        var config = {
            method: "DELETE",
            url: baseUrl,
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        };
        return $http(config);
        this.deleteID = "";
    }

    this.searchUser = function () {

        var searchedUser = {};

        var baseUrl = 'http://10.0.16.51:3000/users' + this.searchID;
        // var baseUrl = 'http://10.0.16.28:3000/users/' + this.searchID;

        var config = {
            method: "GET",
            url: baseUrl,
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        };
        return this.searchedUser = $http(config).response.data;
        this.searchID = "";
    }
});


