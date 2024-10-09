using User.Api.Models.Dto;

namespace User.Api.Services;

public interface IUsersService
{
    Task CreateAsync(CreateUser model);
    Task<GetUserDetails?> GetUserAsync(string id, CancellationToken cancellationToken);
    Task<GetUsers> GetUsersAsync(CancellationToken cancellationToken);
}