using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using IOTProject.DanhMuc.Dtos;

namespace IOTProject.DanhMuc
{
    public interface IDM_THONGTINQUANLYAppService : IApplicationService
    {
        Task<PagedResultDto<DM_THONGTINQUANLYDto>> GetDM_THONGTINQUANLYs(GetDM_THONGTINQUANLYs input);
        Task<DM_THONGTINQUANLYDto> GetForEdit(GetDM_THONGTINQUANLY input);
        void CreateDM_THONGTINQUANLY(CreateOrEditDM_THONGTINQUANLY input);
        void UpdateDM_THONGTINQUANLY(CreateOrEditDM_THONGTINQUANLY input);
        void Delete(EntityDto<int> input);
    }
}
