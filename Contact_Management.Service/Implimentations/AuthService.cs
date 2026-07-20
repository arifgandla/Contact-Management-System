using Contact_Management.DTOs;
using Contact_Management.DTOS;
using Contact_Management.Repository;

namespace Contact_Management.Service;

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

    public async Task<AuthResponseDTO> RegisterAsync(RegisterDTO dto)
    {
        var result = await _authRepository.RegisterAsync(dto);

        if (!result)
        {
            return new AuthResponseDTO
            {
                Success = false,
                Message = "User already exists or registration failed."
            };
        }

        return new AuthResponseDTO
        {
            Success = true,
            Message = "User registered successfully."
        };
    }

    public async Task<AuthResponseDTO> LoginAsync(LoginDTO dto)
    {
        var user = await _authRepository.LoginAsync(dto);

        if (user == null)
        {
            return new AuthResponseDTO
            {
                Success = false,
                Message = "Invalid Email or Password."
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