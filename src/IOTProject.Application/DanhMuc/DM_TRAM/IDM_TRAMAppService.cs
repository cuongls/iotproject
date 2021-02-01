using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using IOTProject.DanhMuc.Dtos;

namespace IOTProject.DanhMuc
{
    public interface IDM_TRAMAppService : IApplicationService
    {
        Task<PagedResultDto<DM_TRAMDto>> GetDM_TRAMs(GetDM_TRAMs input);
        Task<DM_TRAMDto> GetForEdit(GetDM_TRAM input);
        void CreateDM_TRAM(CreateOrEditDM_TRAM input);
        void UpdateDM_TRAM(CreateOrEditDM_TRAM input);
        void Delete(EntityDto<int> input);
    }
}
