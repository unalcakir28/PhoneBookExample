using Report.Business.Dtos.ContactServiceDtos;

namespace Report.Business
{
    public interface IContactService
    {
        public Task<List<ContactDto>> GetAllByLocation(string location);
    }
}
