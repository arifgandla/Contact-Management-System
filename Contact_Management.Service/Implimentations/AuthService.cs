using Contact_Management.DTOs;
using Contact_Management.DTOS;
using Contact_Management.Models;
using Contact_Management.Repository;

namespace Contact_Management.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        private readonly IJwtService _jwtService;

        public AuthService(
            IAuthRepository repository,
            IJwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseDTO> RegisterAsync(RegisterDTO dto)
        {
            var existingUser = await _repository.GetUserByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                return new AuthResponseDTO
                {
                    Success = false,
                    Message = "Email already exists."
                };
            }

            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.Phone
            };

            var result = await _repository.CreateUserAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                return new AuthResponseDTO
                {
                    Success = false,
                    Message = string.Join(", ", result.Errors.Select(x => x.Description))
                };
            }

            return new AuthResponseDTO
            {
                Success = true,
                Message = "Registration Successful"
            };
        }

        public async Task<AuthResponseDTO> LoginAsync(LoginDTO dto)
        {
            var user =
                await _repository.GetUserByEmailAsync(dto.Email);

            if (user == null)
            {
                return new AuthResponseDTO
                {
                    Success = false,
                    Message = "Invalid Email"
                };
            }

            var validPassword =
                await _repository.CheckPasswordAsync(user, dto.Password);

            if (!validPassword)
            {
                return new AuthResponseDTO
                {
                    Success = false,
                    Message = "Invalid Password"
                };
            }

            var token = _jwtService.GenerateToken(user);

            return new AuthResponseDTO
            {
                Success = true,
                Message = "Login Successful",
                Token = token,
                User = new
                {
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.PhoneNumber
                }
            };
        }
    }
}