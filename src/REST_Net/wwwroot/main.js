var app = angular.module('bandtracker', ['ngResource']);

app.config(function($httpProvider, $resourceProvider){
    $resourceProvider.defaults.stripTrailingSlahes = false;
});

app.controller('BandData', function ($scope, $http) {
    $scope.find = function () {
        console.log(this.search_item);
        var item_no_space = this.search_item.split(' ').join('')
        $http.get('http://localhost:23244/api/values/' + item_no_space).success(function (response) {
                json = JSON.parse(response);
                $scope.locations = json.data;
                if (typeof $scope.locations == 'object')
                    console.log($scope.locations);
                else
                    console.log('Not actually an object, it really is ', typeof $scope.greeting);
            });
    };
});

app.controller('BandsController', function ($scope) {
$scope.persons= [
			{
				"name": "Gregory Huffman",
				"email": "Praesent@pedenec.net",
				"birthdate": "2015-03-23T18:00:37-07:00",
				"phonenumber": "07624 073918",
				"address": "5880 Sed, Street",
				"city": "Denderbelle",
				"country": "Ethiopia"
			}
		]
});