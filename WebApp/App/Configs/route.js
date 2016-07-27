(function () {
    'use strict';

    angular.module('app').config(Configure);

    Configure.$inject = ['$routeProvider'];

    function Configure($routeProvider) {
        $routeProvider
            .when('/ToDo', {
                controller: 'ToDoController',
                templateUrl: 'Templates/ToDo/Principal.html'
            })
            .otherwise({ redirectTo: '/ToDo' });
    }
})();