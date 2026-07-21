using Contact_Management.Models;
using Microsoft.AspNetCore.Identity;

namespace Contact_Management.Repository
{
    public interface IAuthRepository
    {
        Task<ApplicationUser?> GetUserByEmailAsync(string email);

        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);

        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);

        Task SaveChangesAsync();
    }
}