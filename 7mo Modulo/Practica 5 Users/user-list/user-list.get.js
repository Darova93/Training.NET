app.controller('GetController', function UserController($scope, $http) {
    // $http.get("http://10.0.16.28:3000/users/").then(function (response) {
    //     $scope.myData = response.data;
    // });

    $http.get("http://10.0.16.51:3000/users/").then(function (response) {
        $scope.myData = response.data;
    });
});