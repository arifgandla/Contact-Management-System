using Contact_Management.Data;
using Contact_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management.Repository;

public class ContactRepository : IContactRepository
{
    private readonly ApplicationDbContext _context;

    public ContactRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contact>> GetAllAsync(string userId)
    {
        return await _context.Contacts
            .Where(c => c.UserId == userId)
            .ToListAsync();
    }

    public async Task<Contact?> GetByIdAsync(int id, string userId)
    {
        return await _context.Contacts
            .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
    }

    public async Task AddAsync(Contact contact)
    {
        await _context.Contacts.AddAsync(contact);
    }

    public void Delete(Contact contact)
    {
        _context.Contacts.Remove(contact);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}