(function () {
    angular.module('app')
        .controller('app.views.comprobantes.input', [
            '$http', '$scope', '$filter', '$uibModalInstance', '$uibModal', 'abp.services.app.comprobante', 'parameters',
            function ($http, $scope, $filter, $uibModalInstance, $uibModal, vService, parameters) {

                var vm = this;                

                vm.data = {};

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
                                        vService.delete(vm.data)
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

                function inicializar() {
                    vm.action = parameters.action;
                    vm.enabled = false;
                    vm.hide = vm.action == 'Consultar';
                    if (vm.action == "Insertar") {
                        vService.initialize()
                            .then(function (result) {
                                vm.data = result.data;
                            });
                    } else {
                        vService.get({
                            id: parameters.idRecord
                        })
                            .then(function (result) {
                                vm.data = result.data;
                                calculaTotales();                                                                
                            });
                        if (vm.action === "Eliminar" || vm.action === "Consultar") {
                            vm.enabled = true;
                        }
                    }                    
                }

                inicializar();
              

                $scope.$watch('vm.data.fecha', function (newValue) {
                    $scope.vm.data.fecha = $filter('date')(newValue, 'dd/MM/yyyy');
                });

                vm.deleteDetalleCuenta = function (index) {
                    vm.data.comprobanteDetalleCuenta.splice(index, 1);
                    calculaTotales();
                };

                vm.editDetalleCuenta = function (index) {                    
                    var dataDetalle = { };
                    Object.assign(dataDetalle, vm.data.comprobanteDetalleCuenta[index]);                        
                    showDetalle('Modificar', dataDetalle, index);      
                    calculaTotales();
                    
                };

                vm.addDetalleCuenta = function () { 
                    var dataDetalle = {};
                    vService.inciarlizarDetalleCuenta()
                        .then(function (result) {
                            dataDetalle = result.data;
                            showDetalle('Insertar', dataDetalle, -1);
                            calculaTotales();
                        });               
                    
                };

                vm.insertDetalleCuenta = function (index) {
                    var dataDetalle = {};
                    vService.inciarlizarDetalleCuenta()
                        .then(function (result) {
                            dataDetalle = result.data;
                            showDetalle('AgregarAntes', dataDetalle, index);
                            calculaTotales();
                        });
                   
                };

                function showDetalle(actionDetalle, vRecordDetalle, indexdetalle) {
                    var modalInstanceDetalle = $uibModal.open({
                        templateUrl: '/App/Main/views/comprobantes/inputDetalle.cshtml',
                        controller: 'app.views.comprobantes.inputDetalle as vm',
                        backdrop: 'static',
                        resolve: {
                            parameters: {
                                action: actionDetalle,
                                data: vRecordDetalle,
                                index: indexdetalle
                            }
                        }
                    });
                    modalInstanceDetalle.rendered.then(function () {
                        $.AdminBSB.input.activate();
                    });
                    modalInstanceDetalle.result.then(function (result) {
                        guardarDetalle(result);
                        calculaTotales();
                    });
                }

                function guardarDetalle(vRecordDetalle) {
                  
                    if (vRecordDetalle.action == 'Modificar') {
                        vm.data.comprobanteDetalleCuenta.splice(vRecordDetalle.indexDetalle, 1, vRecordDetalle.data);
                    } else if (vRecordDetalle.action == 'AgregarAntes') {                        
                        vm.data.comprobanteDetalleCuenta.splice(vRecordDetalle.indexDetalle, 0, vRecordDetalle.data);
                    } else {
                        //vm.data.comprobanteDetalleCuenta.push({ 'cuentaId': vRecordDetalle.data.cuentaId, 'cuentaCodigo': vRecordDetalle.data.cuentaCodigo, 'cuentaDescripcion': vRecordDetalle.data.cuentaDescripcion, 'descripcion': vRecordDetalle.data.descripcion, 'fecha': vRecordDetalle.data.fecha, 'montoDebe': vRecordDetalle.data.montoDebe, 'montoHaber': vRecordDetalle.data.montoHaber });
                        vm.data.comprobanteDetalleCuenta.push(vRecordDetalle.data);
                    }                
                    calculaTotales();                    
                };

                function calculaTotales() {
                    vm.data.totalDebe = vm.data.comprobanteDetalleCuenta.map(function (item) {
                        return {
                            monto: item.montoDebe
                        };
                    }).reduce(sum, 0);
                    vm.data.totalHaber = vm.data.comprobanteDetalleCuenta.map(function (item) {
                        return {
                            monto: item.montoHaber
                        };
                    }).reduce(sum, 0);
                    vm.data.total = vm.data.totalHaber - vm.data.totalDebe;
                }

                function sum(total, num) {
                    if (typeof num.monto == 'undefined') {
                        return total;
                    }
                    return total + Math.round(num.monto);
                }
            }
        ]);
})();