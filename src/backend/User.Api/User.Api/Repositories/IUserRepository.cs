using User.Api.Dto;

namespace User.Api.Repositories;

public interface IUserRepository
{
    Task CreateAsync(string name, string email, string cprNumber, string? phone, string password);
    Task<GetUserDetails> GetAsync(Guid id);
    Task<GetUsers> GetAllAsync();
}