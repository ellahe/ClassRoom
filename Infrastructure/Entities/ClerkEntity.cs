using System.ComponentModel.DataAnnotations;
using Domain.Domains;

namespace Infrastructure.Entities
{
    public class ClerkEntity : Entity
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
