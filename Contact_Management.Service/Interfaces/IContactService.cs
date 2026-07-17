using Contact_Management.DTOs;
using Contact_Management.Models;

namespace Contact_Management.Service;

public interface IContactService
{
    Task<IEnumerable<Contact>> GetAllAsync(string userId);


    Task<Contact?> GetByIdAsync(int id, string userId);

    Task<Contact> CreateAsync(Contact contact);

    Task<Contact?> UpdateAsync(int id, Contact contact, string userId);

    Task<bool> DeleteAsync(int id, string userId);
}