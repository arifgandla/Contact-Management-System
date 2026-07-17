using Contact_Management.DTOS;
using Contact_Management.Models;
using Contact_Management.Repository;

namespace Contact_Management.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;

        public AuthService(
            IAuthRepository authRepository,
            IJwtService jwtService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        public async Task<bool> RegisterAsync(RegisterDTO dto)
        {
            return await _authRepository.RegisterAsync(dto);
        }

        public async Task<(string Token, ApplicationUser User)?> LoginAsync(LoginDTO dto)
        {
            var user = await _authRepository.LoginAsync(dto);

            if (user == null)
                return null;

            var token = _jwtService.GenerateToken(user);

            return (token, user);
        }
    }
}