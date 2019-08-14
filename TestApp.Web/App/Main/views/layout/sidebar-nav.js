(function () {
    var controllerId = 'app.views.layout.sidebarNav';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$state', 'appSession',
        function ($rootScope, $state, appSession) {
            var vm = this;

            vm.menuItems = [
                createMenuItem(App.localize("HomePage"), "", "home", "home"),

                createMenuItem(App.localize("Tenants"), "Pages.Tenants", "business", "tenants"),
                createMenuItem(App.localize("Users"), "Pages.Users", "people", "users"),
                createMenuItem(App.localize("Roles"), "Pages.Roles", "local_offer", "roles"),                
                createMenuItem(App.localize("TestApp"), "", "menu", "", [
                    createMenuItem("TiposNumeracion", "", "receipt", "tiposnumeracion"),
                    createMenuItem("Periodo", "", "payment", "", [
                        createMenuItem("Periodos", "", "line_weight", "periodos"),
                        createMenuItem("Cuentas", "", "gavel", "cuentas"),
                        createMenuItem("Comprobantes", "", "free_breakfast", "comprobantes"),                        
                    ])
                ]),
                createMenuItem("WebAPI", "", "info", "webapi"),
                createMenuItem(App.localize("About"), "", "info", "about")

            ];

            vm.showMenuItem = function (menuItem) {
                if (menuItem.permissionName) {
                    return abp.auth.isGranted(menuItem.permissionName);
                }

                return true;
            }

            function createMenuItem(name, permissionName, icon, route, childItems) {
                return {
                    name: name,
                    permissionName: permissionName,
                    icon: icon,
                    route: route,
                    items: childItems
                };
            }
        }
    ]);
})();