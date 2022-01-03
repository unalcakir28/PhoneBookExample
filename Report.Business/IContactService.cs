using Report.Business.Dtos.ContactServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business
{
    public interface IContactService
    {
        public Task<List<ContactDto>> GetAllByLocation(string location);
    }
}
