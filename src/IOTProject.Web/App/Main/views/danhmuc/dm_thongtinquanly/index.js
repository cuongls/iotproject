//@TODO: Đổi tên app.views.dmdcChucVu.index ở file index.js và index.cshtml tương ứng với controller
//@TODO: Đổi tên abp.services.app.cHUCVU tương ứng với app service
(function () {
    angular.module('app').controller('app.views.DM_THONGTINQUANLY.index', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.dM_THONGTINQUANLY',
        function ($scope, $timeout, $uibModal, localService) {
            var vm = this;
            //Định nghĩa các biến 
            //@TODO: Đổi tên địa chỉ dẫn tới file view
            var createOrEditTemplate = '/App/Main/views/DanhMuc/dm_thongtinquanly/createOrEditModal.cshtml';            
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
                localService.getDM_THONGTINQUANLYs({
                    Filter: vm.Filter,                    
                    maxResultCount: $scope.itemsPerPage,
                    SkipCount: ($scope.currentPage-1)*$scope.itemsPerPage
                }).then(function (result) { 
                    vm.objEntitys = result.data.items;
                    $scope.totalItems = result.data.totalCount;                    
                });                
            };            

            //@TODO: Đổi tên controller tương ứng - app.views.chucvus.createModal
            vm.openCreationModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: createOrEditTemplate,
                    controller: 'app.views.DM_THONGTINQUANLY.createOrEditModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return 0;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getAll();
                });
            };

            //@TODO: Đổi tên controller tương ứng - app.views.chucvus.createModal
            vm.openEditModal = function (obj) {
                var modalInstance = $uibModal.open({
                    templateUrl: createOrEditTemplate,
                    controller: 'app.views.DM_THONGTINQUANLY.createOrEditModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return obj.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    $timeout(function () {
                        $.AdminBSB.input.activate();
                    }, 0);
                });

                modalInstance.result.then(function () {
                    getAll();
                });
            };
            
            vm.delete = function (obj) {
                abp.message.confirm(
                    "Bạn chắc chắn muốn xóa '" + obj.tenchucvu + "'?",
                    "Delete",
                    function (result) {
                        if (result) {
                            localService.delete({ id: obj.id })
                                .then(function () {
                                    abp.notify.info("Đã xóa " + obj.tenchucvu);
                                    getAll();
                                });
                        }
                    });
            }

           
            vm.refresh = function () {
                $scope.setPage(1);
                getAll();
            };

            //Default on page load
            getAll();
                  
        }
    ]);
})();
