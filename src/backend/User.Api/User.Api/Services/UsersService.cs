﻿using User.Api.Dto;
using User.Api.Repositories;

namespace User.Api.Services
{
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

        public async Task<GetUserDetails?> GetUserAsync(Guid id) => await _repository.GetAsync(id);

        public async Task<GetUsers> GetUsersAsync() => await _repository.GetAllAsync();
    }
}