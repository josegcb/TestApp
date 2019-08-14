(function () {
    angular.module('app').controller('app.views.periodos.index', [
        '$http', '$scope', '$timeout', '$uibModal', 'abp.services.app.periodo',
        function ($http, $scope, $timeout, $uibModal, vService) {  
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

            vm.escoger = function (data) {                
                $http({
                    method: "POST",
                    url: "/Home/Escoger",
                    dataType: 'json',
                    data: {
                        PeriodoId: data.id
                    },
                    headers: {
                        "Content-Type": "application/json"
                    }
                }).then(function (result) {
                    if (result.data.success) {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                    } else {
                        abp.notify.error(App.localize('SavedError'));
                    }
                });
            };
           
            function OpenModalForAction(idRecord, action) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/periodos/input.cshtml',
                    controller: 'app.views.periodos.input as vm',
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