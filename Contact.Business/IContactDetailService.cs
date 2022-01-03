using Contact.Business.Base;
using Contact.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business
{
    public interface IContactDetailService : IEntityService<Entity.ContactDetail>
    {
        public Task<List<ContactDetail>> GetAllByContactId(int contactId);
    }
}
