using Contact_Management.DTOS;
using Contact_Management.Models;

namespace Contact_Management.Repository
{
    public interface IAuthRepository
    {
        Task<bool> RegisterAsync(RegisterDTO dto);

        Task<ApplicationUser?> LoginAsync(LoginDTO dto);
    }
}