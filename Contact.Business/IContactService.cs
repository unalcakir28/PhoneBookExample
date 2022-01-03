using Contact.Business.Base;

namespace Contact.Business
{
    public interface IContactService : IEntityService<Entity.Contact>
    {
        public Task<List<Entity.Contact>> GetAllByLocation(string location);
    }
}
