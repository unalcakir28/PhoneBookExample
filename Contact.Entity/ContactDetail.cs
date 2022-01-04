using Contact.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Contact.Entity
{
    public class ContactDetail : EntityBase, IEntity
    {
        public int ContactId { get; set; }

        public ContactDetailType ContactDetailType { get; set; }

        [MaxLength(500)]
        public string Value { get; set; }
    }
}
