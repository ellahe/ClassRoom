using ApplicationService.Common;
using Domain.Domains.Enums;

namespace ApplicationService.Students
{
    public class StudentDTO : ClientDTO
    {
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public Graduation Graduation { get; set; }
    }
}
