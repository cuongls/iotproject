//@TODO: Đổi tên app.views.chucvus.createModal tương ứng với định nghĩa trên index.js
//@TODO: Đổi tên abp.services.app.cHUCVU tương ứng với app service
(function () {
    angular.module('app').controller('app.views.DM_ThietBi.createOrEditModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.dM_ThietBi', 'id',
        function ($scope, $uibModalInstance, localService, id) {
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

            init();
        }
    ]);
})();