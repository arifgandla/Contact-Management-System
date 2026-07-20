using Contact_Management.Models;

namespace Contact_Management.Repository;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllAsync(string userId);

    Task<Contact?> GetByIdAsync(int id, string userId);

    Task AddAsync(Contact contact);

    void Delete(Contact contact);

    Task SaveChangesAsync();
}