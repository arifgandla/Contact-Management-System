using Contact_Management.DTOs;

namespace Contact_Management.Service;

public interface IContactService
{
    Task<IEnumerable<ContactResponseDTO>> GetAllAsync(string userId);
    Task<ContactResponseDTO?> GetByIdAsync(int id, string userId);
    Task<ContactResponseDTO> CreateAsync(CreateContactDTO dto, string userId);
    Task<ContactResponseDTO?> UpdateAsync(int id, UpdateContactDTO dto, string userId);
    Task<bool> DeleteAsync(int id, string userId);
}