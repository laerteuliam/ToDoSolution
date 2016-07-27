(function () {
    'use strict';

    angular
        .module('app')
        .controller('ToDoController', ToDoController);

    ToDoController.$inject = ['$location','ToDoService','$route']; 

    function ToDoController($location, ToDoService, $route) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'ToDoController';
        vm.ToDo = { Descricao: '', Status: 0 };;
        vm.ToDoList = [];
        vm.ItemEmEdicao = 0;

        vm.salvar = salvar;
        vm.listar = listar;
        vm.deletar = deletar;
        vm.alterarStatus = alterarStatus;
        vm.habilitarEdicao = habilitarEdicao;
        vm.cancelar = cancelar;
        vm.limpar = limpar;
        vm.editar = editar;
        vm.adicionar = adicionar;

        function limpar() {
            vm.ToDo.Descricao = '';
        }

        function cancelar() {
            vm.ItemEmEdicao = 0;
            listar();
        }

        function habilitarEdicao(id) {
            vm.ItemEmEdicao = id;
        }

        function alterarStatus(item) {
            item.Status = item.Status==0 ? 1 : 0;
            salvar(item);
        }

        function adicionar(item) {
            salvar(item);
        }

        function editar(item) {
            salvar(item);
            vm.ItemEmEdicao = 0;
        }

        function salvar(item) {
            ToDoService.salvar(item)
            .then(success, fail);

            function success(request) {
                listar();
                limpar();
            }

            function fail(request) {
                //alert('Erro');
            }
        }

        function listar() {
            ToDoService.listar()
            .then(success, fail);

            function success(request) {
                vm.ToDoList = request.data;
            }

            function fail(request) {
                //alert('Erro');
            }
        }

        function deletar(id) {
            ToDoService.deletar(id)
            .then(success, fail);

            function success(request) {
                listar();
            }

            function fail(request) {
                //alert('Erro');
            }
        }


        activate();

        function activate() {
            listar();
        }
    }
})();
