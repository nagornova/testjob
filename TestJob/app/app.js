var app = angular.module('app', ['ngRoute', 'ui.bootstrap', 'ngGrid']);
app.config(
    function ($routeProvider, $httpProvider, $locationProvider) {

        $routeProvider
            .when('/addresses', { templateUrl: 'app/views/addresses/addressList.html', controller: 'AddressController' })

            .otherwise({ redirectTo: '/addresses' });
    }
);