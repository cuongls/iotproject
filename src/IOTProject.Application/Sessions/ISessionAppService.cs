using System.Threading.Tasks;
using Abp.Application.Services;
using IOTProject.Sessions.Dto;

namespace IOTProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
