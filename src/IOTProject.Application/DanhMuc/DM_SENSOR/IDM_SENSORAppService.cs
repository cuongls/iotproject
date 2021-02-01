using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using IOTProject.DanhMuc.Dtos;

namespace IOTProject.DanhMuc
{
    public interface IDM_SENSORAppService : IApplicationService
    {
        Task<PagedResultDto<DM_SENSORDto>> GetDM_SENSORs(GetDM_SENSORs input);
        Task<DM_SENSORDto> GetForEdit(GetDM_SENSOR input);
        void CreateDM_SENSOR(CreateOrEditDM_SENSOR input);
        void UpdateDM_SENSOR(CreateOrEditDM_SENSOR input);
        void Delete(EntityDto<int> input);
    }
}
