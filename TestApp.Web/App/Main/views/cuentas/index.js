(function () {
    angular.module('app').controller('app.views.cuentas.index', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.cuenta',
        function ($scope, $timeout, $uibModal, vService) {  
            var vm = this;
            vm.registros = [];

            function inicializar () {
                getRegistros();
            };            
            function getRegistros() {
                vService.getAll({}).then(function (result) {
                    vm.registros = result.data;
                });
            }             
            vm.refresh = function () {
                getRegistros();
            };
            vm.crearModal = function () {
                OpenModalForAction(0, "Insertar");
            };
            vm.modificarModal = function (data) {
                OpenModalForAction(data.id, "Modificar");
            };
            vm.eliminarModal = function (data) {
                OpenModalForAction(data.id, "Eliminar");
            };
            vm.consultarModal = function (data) {
                OpenModalForAction(data.id, "Consultar");
            };                      
            function OpenModalForAction(idRecord, action) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/cuentas/input.cshtml',
                    controller: 'app.views.cuentas.input as vm',
                    backdrop: 'static',
                    resolve: {
                        parameters: {
                            idRecord: idRecord,
                            action: action
                        }
                    }
                });
                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });
                modalInstance.result.then(function () {
                    getRegistros();
                });
            }
          
            inicializar();
        }
    ]);
})();