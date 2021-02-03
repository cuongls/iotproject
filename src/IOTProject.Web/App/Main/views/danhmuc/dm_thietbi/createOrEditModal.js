//@TODO: Đổi tên app.views.chucvus.createModal tương ứng với định nghĩa trên index.js
//@TODO: Đổi tên abp.services.app.cHUCVU tương ứng với app service
(function () {
    angular.module('app').controller('app.views.DM_ThietBi.createOrEditModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.dM_ThietBi', 'id', 'abp.services.app.dM_TRAM',
        function ($scope, $uibModalInstance, localService, id, dM_TRAMService) {
            var vm = this;
            vm.title = "Thêm mới";
            vm.objEntity = { 
                id: id
            };

            //Init when edit
            var init = function () {
                if (id == 0) return;
                localService.getForEdit({ id: id })
                    .then(function (result) {
                        vm.objEntity = result.data;
                        vm.objEntity.idtram = result.data.idtram + '';
                        vm.title = "Sửa";
                    });
            }

            //@TODO: Đổi tên createCHUCVU
            //@TODO: Đổi tên createCHUCVU
            vm.save = function () {    
                if (id == 0) {
                    localService.createDM_ThietBi(vm.objEntity)
                        .then(function () {
                            abp.notify.info(App.localize('SavedSuccessfully'));
                            $uibModalInstance.close();
                        });
                } else {
                    localService.updateDM_ThietBi(vm.objEntity)
                        .then(function () {
                            abp.notify.info(App.localize('SavedSuccessfully'));
                            $uibModalInstance.close();
                        });
                }
                
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };
            function GetAllTram() {
                dM_TRAMService.getDM_TRAMs({
                    Filter: "",
                    maxResultCount: 99,
                    SkipCount: 0
                }).then(function (result) {
                    vm.trams = result.data.items;
                    vm.objEntity.idtram = vm.trams[0].id + '';
                });
            }
            GetAllTram();
            init();
        }
    ]);
})();