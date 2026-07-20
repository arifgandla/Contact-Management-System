using Contact_Management.DTOs;
using Contact_Management.Models;
using Contact_Management.Repository;

namespace Contact_Management.Service;

public class ContactService : IContactService
{
    private readonly IContactRepository _repository;

    public ContactService(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ContactResponseDTO>> GetAllAsync(string userId)
    {
        var contacts = await _repository.GetAllAsync(userId);

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
        var contact = await _repository.GetByIdAsync(id, userId);

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

        await _repository.AddAsync(contact);
        await _repository.SaveChangesAsync();

        return new ContactResponseDTO
        {
            Id = contact.Id,
            Name = contact.Name,
            Email = contact.Email,
            Phone = contact.Phone
        };
    }

    public async Task<ContactResponseDTO?> UpdateAsync(int id, UpdateContactDTO dto, string userId)
    {
        var contact = await _repository.GetByIdAsync(id, userId);

        if (contact == null)
            return null;

        if (!string.IsNullOrWhiteSpace(dto.Name))
            contact.Name = dto.Name;

        if (!string.IsNullOrWhiteSpace(dto.Email))
            contact.Email = dto.Email;

        if (!string.IsNullOrWhiteSpace(dto.Phone))
            contact.Phone = dto.Phone;

        await _repository.SaveChangesAsync();

        return new ContactResponseDTO
        {
            Id = contact.Id,
            Name = contact.Name,
            Email = contact.Email,
            Phone = contact.Phone
        };
    }
    public async Task<bool> DeleteAsync(int id, string userId)
    {
        var contact = await _repository.GetByIdAsync(id, userId);

        if (contact == null)
            return false;

        _repository.Delete(contact);

        await _repository.SaveChangesAsync();

        return true;
    }
}