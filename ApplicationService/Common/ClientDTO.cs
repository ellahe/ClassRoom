using Domain.Domains.Enums;

namespace ApplicationService.Common
{
    public class ClientDTO
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
    }
}
