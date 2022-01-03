namespace Contact.API.Models.ContactModels
{
    public class ContactUpdateDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }
    }
}
