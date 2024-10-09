using Users.Api.Models.Dto;

namespace Users.Api.Services;

public interface IUsersService
{
    Task CreateAsync(CreateUser model);
    Task<GetUserDetails?> GetUserAsync(string id, CancellationToken cancellationToken);
    Task<GetUsers> GetUsersAsync(CancellationToken cancellationToken);
}