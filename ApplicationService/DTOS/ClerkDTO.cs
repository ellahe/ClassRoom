using ApplicationService.Common;

namespace ApplicationService.DTOS
{
    public class ClerkDTO : ClientDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
