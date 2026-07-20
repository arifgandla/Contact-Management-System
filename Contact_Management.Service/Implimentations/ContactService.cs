using Contact_Management.DTOs;
using Contact_Management.Models;
using Contact_Management.Repository;

namespace Contact_Management.Service;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<IEnumerable<ContactResponseDTO>> GetAllAsync(string userId)
    {
        var contacts = await _contactRepository.GetAllAsync(userId);

        return contacts.Select(c => new ContactResponseDTO
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            Phone = c.Phone
        });
    }

    public async Task<ContactResponseDTO?> GetByIdAsync(int id, string userId)
    {
        var contact = await _contactRepository.GetByIdAsync(id, userId);

        if (contact == null)
            return null;

        return new ContactResponseDTO
        {
            Id = contact.Id,
            Name = contact.Name,
            Email = contact.Email,
            Phone = contact.Phone
        };
    }

    public async Task<ContactResponseDTO> CreateAsync(CreateContactDTO dto, string userId)
    {
        var contact = new Contact
        {
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            UserId = userId
        };

        var created = await _contactRepository.CreateAsync(contact);

        return new ContactResponseDTO
        {
            Id = created.Id,
            Name = created.Name,
            Email = created.Email,
            Phone = created.Phone
        };
    }

    public async Task<ContactResponseDTO?> UpdateAsync(int id, UpdateContactDTO dto, string userId)
    {
        var contact = new Contact
        {
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone
        };

        var updated = await _contactRepository.UpdateAsync(id, contact, userId);

        if (updated == null)
            return null;

        return new ContactResponseDTO
        {
            Id = updated.Id,
            Name = updated.Name,
            Email = updated.Email,
            Phone = updated.Phone
        };
    }

    public async Task<bool> DeleteAsync(int id, string userId)
    {
        return await _contactRepository.DeleteAsync(id, userId);
    }
}