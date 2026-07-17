using Contact_Management.Data;
using Contact_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management.Repository
{
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

        public async Task<Contact> CreateAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        public async Task<Contact?> UpdateAsync(int id, Contact contact, string userId)
        {
            var existingContact = await _context.Contacts
                .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);

            if (existingContact == null)
                return null;

            if (contact.Name != null)
                existingContact.Name = contact.Name;

            if (contact.Email != null)
                existingContact.Email = contact.Email;

            if (contact.Phone != null)
                existingContact.Phone = contact.Phone;

            await _context.SaveChangesAsync();

            return existingContact;
        }

        public async Task<bool> DeleteAsync(int id, string userId)
        {
            var contact = await _context.Contacts
                .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);

            if (contact == null)
                return false;

            _context.Contacts.Remove(contact);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}