using Contact.Business.Base;
using Contact.Data;
using Contact.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business
{
    public class ContactDetailService : EntityServiceBase<Entity.ContactDetail>, IContactDetailService
    {
        public async Task<List<ContactDetail>> GetAllByContactId(int contactId)
        {
            using (var db = new ContactDbContext())
            {
                return await db.ContactDetails
                               .AsNoTracking()
                               .Where(w => !w.isDeleted && w.ContactId == contactId)
                               .ToListAsync();
            }
        }

    }
}
