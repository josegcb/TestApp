(function () {
    angular.module('app')
        .controller('app.views.tiposnumeracion.input', [
            '$http', '$scope', '$uibModalInstance', 'abp.services.app.tipoNumeracion', 'parameters',
            function ($http, $scope, $uibModalInstance, vService, parameters) {

                var vm = this;
                vm.data = {
                    nombre: '',
                    TimeStamp: null
                };
                vm.enabled = false;
                vm.action = parameters.action;
                vm.data.id = parameters.idRecord;
                vm.hide = vm.action == 'Consultar';
               
                vm.save = function () {
                    switch (vm.action) {
                        case "Insertar":
                            vService.create(vm.data)
                                .then(function () {
                                    abp.notify.info(App.localize('SavedSuccessfully'));
                                    $uibModalInstance.close();
                                });
                            break;
                        case "Modificar":
                            vService.update(vm.data)
                                .then(function () {
                                    abp.notify.info(App.localize('SavedSuccessfully'));
                                    $uibModalInstance.close();
                                });
                            break;
                        case "Eliminar":
                            abp.message.confirm("Desea eliminar el registro?",
                                function (result) {
                                    if (result) {
                                        vService.delete({
                                            id: idRecord,
                                            timeStamp: vm.data.timeStamp
                                        })
                                            .then(function () {
                                                abp.notify.info("Registro eliminado ");
                                                $uibModalInstance.close();
                                            });
                                    }
                                });
                            break;
                        case "Consultar":
                            break;
                        default:
                    }
                };

                vm.cancel = function () {
                    $uibModalInstance.dismiss({});
                };   
                
                function inicializar () {
                    if (vm.action !== "Insertar") {                        
                        vService.get({
                            id: vm.data.id
                        })
                            .then(function (result) {
                                vm.data = result.data;
                            });
                        if (vm.action === "Eliminar" || vm.action === "Consultar") {
                            vm.enabled = true;
                        }
                    }
                }

                inicializar();               
            }
        ]);
})();