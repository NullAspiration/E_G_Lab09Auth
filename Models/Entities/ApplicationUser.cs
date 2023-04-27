using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_G_Lab09Auth.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [NotMapped]
        public ICollection<string> Roles { get; set;} = new List<string>();

        public bool HasRole(string roleName)
        {
            return Roles.Any(r => r == roleName);
        }

    }
}
