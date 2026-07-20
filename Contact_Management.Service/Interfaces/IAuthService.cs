using Contact_Management.DTOs;
using Contact_Management.DTOS;

namespace Contact_Management.Service
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> RegisterAsync(RegisterDTO dto);

        Task<AuthResponseDTO> LoginAsync(LoginDTO dto);
    }
}