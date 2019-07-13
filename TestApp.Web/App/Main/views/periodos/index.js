(function () {
    angular.module('app').controller('app.views.periodos.index', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.periodo',
        function ($scope, $timeout, $uibModal, vService) {
            var vm = this;
            vm.registros = [];

            function inicializar() {
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
            
            vm.escoger = function (vRecord) {
                var options = {};
                options.url = CrearUrlDinamica("Periodos", 'Escoger');
                options.type = "POST";
                options.data = { "PeriodoId": vRecord.id };
                options.dataType = "json";
                options.success = function (valData) {
                    abp.notify.info(App.localize('SavedSuccessfully'));
                };
                options.error = function (e) { errorMessage(e); };
                $.ajax(options);
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

            function CrearUrlDinamica(valControlador, valAccion) {
                var vUrl = '';
                if (valAccion !== '' && valAccion !== undefined) {
                    vUrl = abp.appPath + valControlador + '/' + valAccion
                } else {
                    vUrl = abp.appPath + valControlador
                }
                return vUrl;
            }
          
            inicializar();
        }
    ]);
})();