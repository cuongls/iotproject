using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IOTProject.Roles.Dto;
using IOTProject.Users.Dto;

namespace IOTProject.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}