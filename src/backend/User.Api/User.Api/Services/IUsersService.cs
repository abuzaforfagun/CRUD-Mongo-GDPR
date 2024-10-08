using User.Api.Dto;

namespace User.Api.Services;

public interface IUsersService
{
    Task CreateAsync(CreateUser model);
    Task<GetUserDetails?> GetUser(Guid id);
    Task<GetUsers> GetUsersAsync();
}