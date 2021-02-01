using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using IOTProject.DanhMuc.Dtos;

namespace IOTProject.DanhMuc
{
    public interface IDM_DonViAppService : IApplicationService
    {
        Task<PagedResultDto<DM_DonViDto>> GetDM_DonVis(GetDM_DonVis input);
        Task<DM_DonViDto> GetForEdit(GetDM_DonVi input);
        void CreateDM_DonVi(CreateOrEditDM_DonVi input);
        void UpdateDM_DonVi(CreateOrEditDM_DonVi input);
        void Delete(EntityDto<int> input);
    }
}
