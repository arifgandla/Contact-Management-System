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

    public async Task<IEnumerable<Contact>> GetAllAsync(string userId)
    {
        return await _contactRepository.GetAllAsync(userId);
    }

    public async Task<Contact?> GetByIdAsync(int id, string userId)
    {
        return await _contactRepository.GetByIdAsync(id, userId);
    }

    public async Task<Contact> CreateAsync(Contact contact)
    {
        return await _contactRepository.CreateAsync(contact);
    }

    public async Task<Contact?> UpdateAsync(int id, Contact contact, string userId)
    {
        return await _contactRepository.UpdateAsync(id, contact, userId);
    }

    public async Task<bool> DeleteAsync(int id, string userId)
    {
        return await _contactRepository.DeleteAsync(id, userId);
    }
}