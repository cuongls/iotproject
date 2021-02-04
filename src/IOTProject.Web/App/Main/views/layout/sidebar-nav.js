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

                createMenuItem(App.localize("Danh mục"), "Pages.Roles", "list", "", [
                    createMenuItem("Đơn vị", "", "list", "dm_donvi"),
                    createMenuItem("Trạm", "", "list", "dm_tram"),
                    createMenuItem("Thiết bị", "list", "", "dm_thietbi"),
                    createMenuItem("Thông tin quản lý", "", "list", "dm_thongtinquanly"),
                    createMenuItem("Sensor", "", "list", "dm_sensor"),
                    createMenuItem("Trạng thái", "", "list", "dm_trangthai")
                ]),
                createMenuItem("Giám sát - Điều khiển", "Pages.Roles", "computer", "thongtingiamsat")
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