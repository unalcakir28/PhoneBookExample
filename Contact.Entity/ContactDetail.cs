using Contact.Entity.Base;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
