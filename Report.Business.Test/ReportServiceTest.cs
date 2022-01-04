using System;
using System.Threading.Tasks;
using Xunit;

namespace Report.Business.Test
{
    public class ReportServiceTest
    {
        public ReportServiceTest()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        [Fact]
        public async Task Create()
        {
            var model = new Entity.Report
            {
                ReportStatus = Entity.ReportStatus.Waiting,
                RequestDate = DateTime.Now,
                RequestLocation = "Test Location"
            };

            var reportService = new ReportService();
            await reportService.Add(model);
            Assert.True(model.Id > 0);
        }

        [Fact]
        public async Task Update()
        {
            var model = new Entity.Report
            {
                ReportStatus = Entity.ReportStatus.Waiting,
                RequestDate = DateTime.Now,
                RequestLocation = "Test Location"
            };
            var changedLocation = "changedLocation";

            var reportService = new ReportService();
            await reportService.Add(model);
            model.RequestLocation = changedLocation;
            await reportService.Update(model);
            var dbModel = await reportService.GetById(model.Id);

            Assert.True(model.Id == dbModel.Id);
            Assert.True(dbModel.RequestLocation == changedLocation);
        }

        [Fact]
        public async Task Delete()
        {
            var model = new Entity.Report
            {
                ReportStatus = Entity.ReportStatus.Waiting,
                RequestDate = DateTime.Now,
                RequestLocation = "Test Location"
            };

            var reportService = new ReportService();
            await reportService.Add(model);
            await reportService.Delete(model);
            var dbModel = await reportService.GetById(model.Id);

            Assert.True(dbModel.isDeleted);
        }

        [Fact]
        public async Task Get()
        {
            var model = new Entity.Report
            {
                ReportStatus = Entity.ReportStatus.Waiting,
                RequestDate = DateTime.Now,
                RequestLocation = "Test Location"
            };

            var reportService = new ReportService();
            await reportService.Add(model);
            var dbModel = await reportService.GetById(model.Id);

            Assert.True(dbModel != null);
            Assert.True(model.Id == dbModel!.Id);
        }

        [Fact]
        public async Task GetAll()
        {
            var reportService = new ReportService();
            var models = await reportService.GetAll();
            Assert.True(models != null);
        }
    }
}