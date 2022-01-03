using Contact.Business.Base;
using Contact.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business
{
    public class ContactService : EntityServiceBase<Entity.Contact>, IContactService
    {
        public virtual async Task<List<Entity.Contact>> GetAllByLocation(string location)
        {
            using (var db = new ContactDbContext())
            {
                return await db.Contacts
                               .AsNoTracking()
                               .AsSplitQuery()
                               .Where(w => !w.isDeleted &&
                                            w.ContactDetails.Any(a => !a.isDeleted && a.ContactDetailType == Entity.ContactDetailType.Address && a.Value.Contains(location)))
                               .Include(w => w.ContactDetails.Where(w => !w.isDeleted))
                               .ToListAsync();
            }
        }
    }
}
