//@TODO: Đổi tên app.views.chucvus.createModal tương ứng với định nghĩa trên index.js
//@TODO: Đổi tên abp.services.app.cHUCVU tương ứng với app service
(function () {
    angular.module('app').controller('app.views.DM_ThietBi.settingModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.dM_ThietBi', 'id', 'abp.services.app.thongTin_ThietBi', 'abp.services.app.dM_THONGTINQUANLY',
        function ($scope, $uibModalInstance, localService, id, thongTin_ThietBiService, thongtinquanlyService) {
            var vm = this;
            vm.title = "Thêm mới";
            vm.objEntity = { 
                idthietbi: id
            };

            //Init when edit
            var init = function () {
                thongTin_ThietBiService.getThongTinQuanLyByIdThietBi(id)
                    .then(function (result) {
                        vm.noidungquanlys = result.data;
                    });
                
            }

            //@TODO: Đổi tên createCHUCVU
            //@TODO: Đổi tên createCHUCVU
            vm.CreateThongTinThietBi = function () {    
                thongTin_ThietBiService.createThongTin_ThietBi(vm.objEntity)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        init();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };
            vm.delete = function (item) {
                abp.message.confirm(
                    "Bạn chắc chắn muốn xóa '" + item.thongtinquanly.name + "'?",
                    "Delete",
                    function (result) {
                        if (result) {
                            thongTin_ThietBiService.delete({ id: item.id })
                                .then(function () {
                                    abp.notify.info("Đã xóa " + item.thongtinquanly.name);
                                    init();
                                });
                        }
                    });
            }
            function getAllThongTinQuanLy() {
                //@TODO: Đổi hàm get tương ứng với service
                thongtinquanlyService.getDM_THONGTINQUANLYs({
                    Filter: "",
                    maxResultCount: 99,
                    SkipCount: 0
                }).then(function (result) {
                    vm.thongtinquanlys = result.data.items;
                });
            };  
            init();
            getAllThongTinQuanLy();
        }
    ]);
})();