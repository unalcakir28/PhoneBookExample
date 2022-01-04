using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Contact.Business.Test
{
    public class ContactServiceTest
    {
        public ContactServiceTest()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        [Fact]
        public async Task Create()
        {
            var model = new Entity.Contact
            {
                Name = "Ünal",
                Surname = "ÇAKIR",
                Company = "Setup34",
            };

            var contactService = new ContactService();
            await contactService.Add(model);
            Assert.True(model.Id > 0);
        }

        [Fact]
        public async Task Update()
        {
            var model = new Entity.Contact
            {
                Name = "Ünal",
                Surname = "ÇAKIR",
                Company = "Setup34",
            };
            var changedName = "changedName";

            var contactService = new ContactService();
            await contactService.Add(model);
            model.Name = changedName;
            await contactService.Update(model);
            var dbModel = await contactService.GetById(model.Id);

            Assert.True(model.Id == dbModel.Id);
            Assert.True(dbModel.Name == changedName);
        }

        [Fact]
        public async Task Delete()
        {
            var model = new Entity.Contact
            {
                Name = "Ünal",
                Surname = "ÇAKIR",
                Company = "Setup34",
            };

            var contactService = new ContactService();
            await contactService.Add(model);
            await contactService.Delete(model);
            var dbModel = await contactService.GetById(model.Id);

            Assert.True(dbModel.isDeleted);
        }

        [Fact]
        public async Task Get()
        {
            var model = new Entity.Contact
            {
                Name = "Ünal",
                Surname = "ÇAKIR",
                Company = "Setup34",
            };

            var contactService = new ContactService();
            await contactService.Add(model);
            var dbModel = await contactService.GetById(model.Id);

            Assert.True(dbModel != null);
            Assert.True(model.Id == dbModel!.Id);
        }

        [Fact]
        public async Task GetAll()
        {
            var contactService = new ContactService();
            var models = await contactService.GetAll();
            Assert.True(models != null);
        }

        [Fact]
        public async Task GetAllByLocation()
        {
            var contact = new Entity.Contact
            {
                Name = "Ünal",
                Surname = "ÇAKIR",
                Company = "Setup34",
            };
            var testLocation = "Test Location";

            var contactService = new ContactService();
            var contactDetailService = new ContactDetailService();
            await contactService.Add(contact);
            await contactDetailService.Add(new Entity.ContactDetail
            {
                ContactDetailType = Entity.ContactDetailType.Address,
                ContactId = contact.Id,
                Value = testLocation
            });
            var model = await contactService.GetAllByLocation(testLocation);

            Assert.True(model != null);
            Assert.True(model!.Any());
        }
    }
}