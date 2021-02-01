using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using IOTProject.ThongTin.Dtos;

namespace IOTProject.ThongTin
{
    public interface IThongTin_ThietBiAppService : IApplicationService
    {
        Task<PagedResultDto<ThongTin_ThietBiDto>> GetThongTin_ThietBis(GetThongTin_ThietBis input);
        Task<ThongTin_ThietBiDto> GetForEdit(GetThongTin_ThietBi input);
        void CreateThongTin_ThietBi(CreateOrEditThongTin_ThietBi input);
        void UpdateThongTin_ThietBi(CreateOrEditThongTin_ThietBi input);
        void Delete(EntityDto<int> input);
    }
}
