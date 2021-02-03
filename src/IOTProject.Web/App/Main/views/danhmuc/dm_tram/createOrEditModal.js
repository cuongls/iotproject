//@TODO: Đổi tên app.views.chucvus.createModal tương ứng với định nghĩa trên index.js
//@TODO: Đổi tên abp.services.app.cHUCVU tương ứng với app service
(function () {
    angular.module('app').controller('app.views.DM_TRAM.createOrEditModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.dM_TRAM', 'id', 'abp.services.app.dM_DonVi',
        function ($scope, $uibModalInstance, localService, id, dM_DonViService) {
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
                        vm.objEntity.iddonvi = result.data.iddonvi + '';
                        vm.title = "Sửa";
                    });
            }

            //@TODO: Đổi tên createCHUCVU
            //@TODO: Đổi tên createCHUCVU
            vm.save = function () {    
                if (id == 0) {
                    localService.createDM_TRAM(vm.objEntity)
                        .then(function () {
                            abp.notify.info(App.localize('SavedSuccessfully'));
                            $uibModalInstance.close();
                        });
                } else {
                    localService.updateDM_TRAM(vm.objEntity)
                        .then(function () {
                            abp.notify.info(App.localize('SavedSuccessfully'));
                            $uibModalInstance.close();
                        });
                }
                
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };
            function GetAllDonVi() {
                dM_DonViService.getDM_DonVis({
                    Filter: "",
                    maxResultCount: 99,
                    SkipCount: 0
                }).then(function (result) {
                    vm.donvis = result.data.items;
                    vm.objEntity.iddonvi = vm.donvis[0].id + '';
                }); 
            }
            GetAllDonVi();
            init();
        }
    ]);
})();