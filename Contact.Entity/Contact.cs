using Contact.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contact.Entity
{
    public class Contact : EntityBase, IEntity
    {

        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Surname { get; set; }

        [MaxLength(250)]
        public string Company { get; set; }

        [ForeignKey("ContactId")]
        public virtual List<ContactDetail> ContactDetails { get; set; }

    }
}
