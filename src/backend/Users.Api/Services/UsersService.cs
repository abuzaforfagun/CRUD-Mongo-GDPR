using User.Api.Repositories;
using User.Api.Services;
using Users.Api.Extensions;
using Users.Api.Models.Dto;

namespace Users.Api.Services;

public class UsersService : IUsersService
{
    private readonly IUserRepository _repository;
    private readonly ICryptographyService _cryptographyService;
    private readonly ILogger<UsersService> _logger;

    public UsersService(IUserRepository repository, ICryptographyService cryptographyService, ILogger<UsersService> logger)
    {
        _repository = repository;
        _cryptographyService = cryptographyService;
        _logger = logger;
    }

    public async Task CreateAsync(CreateUser model)
    {
        try
        {
            var encryptedCpr = _cryptographyService.Encrypt(model.CPRNumber);
            var hashedPassword = _cryptographyService.Hash(model.Password);

            await _repository.CreateAsync(model.FullName, model.Email, encryptedCpr, model?.Phone, hashedPassword);
        }
        catch (Exception ex)
        {
            var maskedUser = model!.GetMaskedData();
            _logger.LogError(
                $"Unable to create user for [Email={maskedUser.Email}] [Fullname={maskedUser.FullName}] [Phone={maskedUser.Phone}] [CPR={maskedUser.CPRNumber}]",
                ex);

            throw;
        }
    }

    public async Task<GetUserDetails?> GetUserAsync(string id, CancellationToken cancellationToken)
    {
        var user = await _repository.GetAsync(id, cancellationToken);

        if (user.CPRNumber != null)
        {
            user.CPRNumber = _cryptographyService.Decrypt(user.CPRNumber);
        }

        return user;
    }

    public async Task<GetUsers> GetUsersAsync(CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllAsync(cancellationToken);

        return new GetUsers
        {
            Users = users.Select(u => new Models.Dto.User
            {
                Name = u.Name,
                Email = u.Email.ToMaskedEmail(),
                Phone = u.Phone?.ToMaskedPhoneNumber(),
                CPRNumber = u.CPRNumber != null ? _cryptographyService.Decrypt(u.CPRNumber!).ToMaskedCPR() : null,
                CreatedAt = u.CreatedAt
            })
        };

    }
}