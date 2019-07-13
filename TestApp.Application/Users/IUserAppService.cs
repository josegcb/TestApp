using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TestApp.Roles.Dto;
using TestApp.Users.Dto;

namespace TestApp.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}