using Contact.API.Models.ContactDetailModels;

namespace Contact.API.Models.ContactModels
{
    public class ContactDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }

        public List<ContactDetailDto> ContactDetails { get; set; }
    }
}
