using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Domains
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public override bool Equals(object obj)
        {
            if (GetType() == obj.GetType())
                if (((Entity)obj).ID == ID) return true;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
