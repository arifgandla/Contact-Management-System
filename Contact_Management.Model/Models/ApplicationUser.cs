using Microsoft.AspNetCore.Identity;

namespace Contact_Management.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

       // public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}