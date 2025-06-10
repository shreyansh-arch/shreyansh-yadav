using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
