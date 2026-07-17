using Contact_Management.Models;

namespace Contact_Management.Service;

public interface IJwtService
{
    string GenerateToken(ApplicationUser user);
}