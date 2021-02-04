//@TODO: Đổi tên app.views.dmdcChucVu.index ở file index.js và index.cshtml tương ứng với controller
//@TODO: Đổi tên abp.services.app.cHUCVU tương ứng với app service
(function () {
    angular.module('app').controller('app.views.thongtin.index', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.dM_ThietBi',
        function ($scope, $timeout, $uibModal, localService) {
            var vm = this;
            //Định nghĩa các biến 
            //@TODO: Đổi tên địa chỉ dẫn tới file view
            var createOrEditTemplate = '/App/Main/views/DanhMuc/dm_thietbi/createOrEditModal.cshtml';            
            var settingTemplate = '/App/Main/views/DanhMuc/dm_thietbi/settingModal.cshtml';            
            //Cấu hình phân trang
            $scope.totalItems = 0;
            $scope.currentPage = 1;
            $scope.maxSize = 5;
            $scope.itemsPerPage = 10;            

            vm.objEntitys = [];

            $scope.setPage = function (pageNo) {
                $scope.currentPage = pageNo;
            };

            $scope.pageChanged = function () {                
                getAll();                
            };               

            function getAll() {  
                //@TODO: Đổi hàm get tương ứng với service
                localService.getListGiamSatThietBi({
                }).then(function (result) { 
                    vm.objEntitys = result.data;
                    console.log(vm.objEntitys);
                });                
            };            

            
            vm.refresh = function () {
                $scope.setPage(1);
                getAll();
            };

            //Default on page load
            getAll();

            var chatHub = $.connection.myChatHub;

            chatHub.client.getMessage = function (message) { // Register for incoming messages
                console.log('received message: ' + message);
            };
                  
        }
    ]);
})();
