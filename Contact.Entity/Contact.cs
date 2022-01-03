using Contact.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
