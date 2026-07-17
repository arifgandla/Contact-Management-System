using Contact_Management.DTOS;
using Contact_Management.Models;

namespace Contact_Management.Service
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDTO dto);

        Task<(string Token, ApplicationUser User)?> LoginAsync(LoginDTO dto);
    }
}