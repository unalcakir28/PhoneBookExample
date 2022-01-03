using Contact.Entity;

namespace Contact.API.Models.ContactDetailModels
{
    public class ContactDetailAddDto
    {
        public int ContactId { get; set; }

        public ContactDetailType ContactDetailType { get; set; }

        public string Value { get; set; }
    }
}
