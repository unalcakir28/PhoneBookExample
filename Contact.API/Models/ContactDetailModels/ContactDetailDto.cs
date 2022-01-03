using Contact.Entity;

namespace Contact.API.Models.ContactDetailModels
{
    public class ContactDetailDto
    {
        public int Id { get; set; }

        public ContactDetailType ContactDetailType { get; set; }

        public string Value { get; set; }
    }
}
