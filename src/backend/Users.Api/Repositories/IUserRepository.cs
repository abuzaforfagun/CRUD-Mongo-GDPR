using User.Api.Models.Dto;

namespace User.Api.Repositories;

public interface IUserRepository
{
    Task CreateAsync(string name, string email, string cprNumber, string? phone, string password);
    Task<GetUserDetails> GetAsync(string id, CancellationToken cancellationToken);
    Task<GetUsers> GetAllAsync(CancellationToken cancellationToken);
}