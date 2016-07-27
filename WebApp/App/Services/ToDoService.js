(function () {
    'use strict';

    angular
        .module('app')
        .service('ToDoService', ToDoService);

    ToDoService.$inject = ['$http','api'];

    function ToDoService($http,api) {
        this.listar = listar;
        this.salvar = salvar;
        this.deletar = deletar;

        function listar() {
            return $http.get(api.uri + 'ToDo');
        }
        function salvar(todo) {
            return $http.post(api.uri + 'ToDo', todo);
        }
        function deletar(id) {
            return $http.delete(api.uri + 'ToDo/'+id);
        }
    }
})();