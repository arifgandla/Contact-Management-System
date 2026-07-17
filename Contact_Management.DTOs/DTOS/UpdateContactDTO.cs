using System.ComponentModel.DataAnnotations;

namespace Contact_Management.DTOs
{
    public class UpdateContactDTO
    {
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Phone { get; set; }
    }
}