using System.ComponentModel.DataAnnotations;

namespace Domain.Domains
{
    public class ClerkEntity : Entity
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
