angular.module("itemListController").component("itemListController",{
    templateUrl: "./item-list.html",
    controller: function itemListController($http){
        var self=this;
        
        $http.get('http://localhost:2048/api/task/getbypriority').then(function(response){
            self.phones = response.data;
        });
    }
});