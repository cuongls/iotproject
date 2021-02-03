using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using IOTProject.DanhMuc.Dtos;

namespace IOTProject.DanhMuc
{
    public interface IDM_ThietBiAppService : IApplicationService
    {
        Task<PagedResultDto<DM_ThietBiDto>> GetDM_ThietBis(GetDM_ThietBis input);
        Task<DM_ThietBiDto> GetForEdit(GetDM_ThietBi input);
        void CreateDM_ThietBi(CreateOrEditDM_ThietBi input);
        void UpdateDM_ThietBi(CreateOrEditDM_ThietBi input);
        void Delete(EntityDto<int> input);
        GiamSatThietBi2Cot GetListGiamSatThietBi(GiamSatInput input);
    }
}
