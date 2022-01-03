using Contact.API.Models.ContactDetailModels;
using Contact.Business;
using Contact.Entity;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers
{
    [ApiController]
    [Route("contactDetail")]
    public class ContactDetailController : Controller
    {
        private readonly ILogger<ContactDetailController> _logger;
        private readonly IContactDetailService _contactDetailService;

        public ContactDetailController(ILogger<ContactDetailController> logger, IContactDetailService contactDetailService)
        {
            _logger = logger;
            _contactDetailService = contactDetailService;
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var contactDetail = await _contactDetailService.GetById(id);

                if (contactDetail == null)
                    return NotFound();

                var contactDetailDto = contactDetail.Adapt<ContactDetailDto>();
                return Ok(contactDetailDto);
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
                var contactDetails = await _contactDetailService.GetAll();

                if (!contactDetails.Any())
                    return NotFound();

                var contactDetailsDto = contactDetails.Select(w => w.Adapt<ContactDetailDto>()).ToList();
                return Ok(contactDetailsDto);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "");
                return StatusCode(500);
            }
        }

        [HttpGet("getAllByContactId")]
        public async Task<IActionResult> GetAllByContactId(int id)
        {
            try
            {
                var contactDetails = await _contactDetailService.GetAllByContactId(id);

                if (!contactDetails.Any())
                    return NotFound();

                var contactDetailsDto = contactDetails.Select(w => w.Adapt<ContactDetailDto>()).ToList();
                return Ok(contactDetailsDto);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "");
                return StatusCode(500);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ContactDetailAddDto contactDetailAddDto)
        {
            try
            {
                var contactDetail = contactDetailAddDto.Adapt<ContactDetail>();
                await _contactDetailService.Add(contactDetail);
                return Ok(contactDetail.Id);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "");
                return StatusCode(500);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ContactDetailUpdateDto contactDetailUpdateDto)
        {
            try
            {
                var contactDetail = await _contactDetailService.GetById(contactDetailUpdateDto.Id);
                contactDetail = contactDetailUpdateDto.Adapt(contactDetail);
                await _contactDetailService.Update(contactDetail);
                return Ok();
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "");
                return StatusCode(500);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var contactDetail = await _contactDetailService.GetById(id);
                await _contactDetailService.Delete(contactDetail);
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