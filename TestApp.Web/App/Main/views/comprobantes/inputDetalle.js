(function () {
    angular.module('app')
        .controller('app.views.comprobantes.inputDetalle', [
            '$http', '$scope', '$filter', '$uibModalInstance',  'abp.services.app.cuenta', 'parameters',
            function ($http, $scope, $filter, $uibModalInstance,  vServiceCuenta, parameters) {

                var vm = this;

                vm.conexionCuenta = [];

                function inicializar() {
                    vm.action = parameters.action;
                    vm.enabled = false;
                    vm.hide = vm.action == 'Consultar';
                    vm.data = parameters.data; 
                    vm.indexDetalle = parameters.index;
                    loadInfoFK();
                }

                inicializar();

                function loadInfoFK() {
                    vServiceCuenta.getAll()
                        .then(function (result) {
                            vm.conexionCuenta = result.data;
                            vm.conexionCuenta.sort(sortByProperty('codigo'));
                        });
                }

                $scope.$watch('vm.data.fecha', function (newValue) {
                    $scope.vm.data.fecha = $filter('date')(newValue, 'dd/MM/yyyy');
                });

                vm.save = function () {
                    var vCuentaSelect = vm.conexionCuenta.filter(function (item) {
                        return item.id == vm.data.cuentaId;
                    }).
                        map(function (item) {
                            return {
                                codigo: item.codigo,
                                descripcion: item.descripcion
                            };
                        });
                    vm.data.cuentaCodigo = vCuentaSelect[0].codigo;
                    vm.data.cuentaDescripcion = vCuentaSelect[0].descripcion;
                    $uibModalInstance.close(vm);
                };     

                vm.cancel = function () {
                    $uibModalInstance.dismiss({});
                };

            }
        ]);
})();