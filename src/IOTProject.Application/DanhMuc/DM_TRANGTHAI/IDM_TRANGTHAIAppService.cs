using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using IOTProject.DanhMuc.Dtos;

namespace IOTProject.DanhMuc
{
    public interface IDM_TRANGTHAIAppService : IApplicationService
    {
        Task<PagedResultDto<DM_TRANGTHAIDto>> GetDM_TRANGTHAIs(GetDM_TRANGTHAIs input);
        Task<DM_TRANGTHAIDto> GetForEdit(GetDM_TRANGTHAI input);
        void CreateDM_TRANGTHAI(CreateOrEditDM_TRANGTHAI input);
        void UpdateDM_TRANGTHAI(CreateOrEditDM_TRANGTHAI input);
        void Delete(EntityDto<int> input);
    }
}
