using Contact.Business.Base;
using Contact.Entity;

namespace Contact.Business
{
    public interface IContactDetailService : IEntityService<Entity.ContactDetail>
    {
        public Task<List<ContactDetail>> GetAllByContactId(int contactId);
    }
}
