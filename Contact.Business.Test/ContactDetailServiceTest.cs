using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Contact.Business.Test
{
    public class ContactDetailServiceTest
    {
        public ContactDetailServiceTest()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        [Fact]
        public async Task Create()
        {
            var model = new Entity.ContactDetail
            {
                ContactDetailType = Entity.ContactDetailType.Phone,
                ContactId = 1,
                Value = "Test Value"
            };

            var contactDetailService = new ContactDetailService();
            await contactDetailService.Add(model);
            Assert.True(model.Id > 0);
        }

        [Fact]
        public async Task Update()
        {
            var model = new Entity.ContactDetail
            {
                ContactDetailType = Entity.ContactDetailType.Phone,
                ContactId = 1,
                Value = "Test Value"
            };
            var changedValue = "changedValue";

            var contactDetailService = new ContactDetailService();
            await contactDetailService.Add(model);
            model.Value = changedValue;
            await contactDetailService.Update(model);
            var dbModel = await contactDetailService.GetById(model.Id);

            Assert.True(model.Id == dbModel.Id);
            Assert.True(dbModel.Value == changedValue);
        }

        [Fact]
        public async Task Delete()
        {
            var model = new Entity.ContactDetail
            {
                ContactDetailType = Entity.ContactDetailType.Phone,
                ContactId = 1,
                Value = "Test Value"
            };

            var contactDetailService = new ContactDetailService();
            await contactDetailService.Add(model);
            await contactDetailService.Delete(model);
            var dbModel = await contactDetailService.GetById(model.Id);

            Assert.True(dbModel.isDeleted);
        }

        [Fact]
        public async Task Get()
        {
            var model = new Entity.ContactDetail
            {
                ContactDetailType = Entity.ContactDetailType.Phone,
                ContactId = 1,
                Value = "Test Value"
            };

            var contactDetailService = new ContactDetailService();
            await contactDetailService.Add(model);
            var dbModel = await contactDetailService.GetById(model.Id);

            Assert.True(dbModel != null);
            Assert.True(model.Id == dbModel!.Id);
        }

        [Fact]
        public async Task GetAll()
        {
            var contactDetailService = new ContactDetailService();
            var models = await contactDetailService.GetAll();
            Assert.True(models != null);
        }

        [Fact]
        public async Task GetAllByContactId()
        {
            var model = new Entity.ContactDetail
            {
                ContactDetailType = Entity.ContactDetailType.Phone,
                ContactId = 1,
                Value = "Test Value"
            };

            var contactDetailService = new ContactDetailService();
            await contactDetailService.Add(model);
            var dbModel = await contactDetailService.GetAllByContactId(model.ContactId);

            Assert.True(dbModel != null);
            Assert.True(dbModel!.Any());
        }
    }
}