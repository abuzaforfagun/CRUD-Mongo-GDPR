using Users.Api.Models.Dto;

namespace User.Api.Repositories;

public interface IUserRepository
{
    Task CreateAsync(string name, string email, string cprNumber, string? phone, string password);
    Task<GetUserDetails> GetAsync(string id, CancellationToken cancellationToken);
    Task<IEnumerable<Users.Api.Models.Dto.User>> GetAllAsync(CancellationToken cancellationToken);
}