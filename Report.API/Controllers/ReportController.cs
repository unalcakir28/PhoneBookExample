using Contact.API.Models.ContactModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Report.Business;

namespace Contact.API.Controllers
{
    [ApiController]
    [Route("report")]
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        private readonly IReportService _reportService;
        private readonly IMQService _mqService;


        public ReportController(ILogger<ReportController> logger, IReportService reportService, IMQService mqService)
        {
            _logger = logger;
            _reportService = reportService;
            _mqService = mqService;
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var report = await _reportService.GetById(id);

                if (report == null)
                    return NotFound();

                var contactDto = report.Adapt<ReportDto>();
                return Ok(contactDto);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "");
                return StatusCode(500);
            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var reports = await _reportService.GetAll();

                if (!reports.Any())
                    return NotFound();

                var contactsDto = reports.Select(w => w.Adapt<ReportDto>()).ToList();
                return Ok(contactsDto);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "");
                return StatusCode(500);
            }
        }

        [HttpGet("request")]
        public async Task<IActionResult> ReportRequest(string location)
        {
            try
            {
                if (string.IsNullOrEmpty(location))
                    return BadRequest();

                var report = new Report.Entity.Report
                {
                    ReportStatus = Report.Entity.ReportStatus.Waiting,
                    RequestDate = DateTime.Now,
                    RequestLocation = location
                };
                await _reportService.Add(report);
                _mqService.SendNewReportRequest(report.Id);
                return Ok();
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "");
                return StatusCode(500);
            }
        }
    }
}