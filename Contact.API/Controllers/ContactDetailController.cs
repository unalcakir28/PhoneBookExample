using Contact.Business;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using Contact.API.Models.ContactDetailModels;
using Contact.Entity;

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
            var contactDetail = await _contactDetailService.GetById(id);

            if (contactDetail == null)
                return NotFound();

            var contactDetailDto = contactDetail.Adapt<ContactDetailDto>();
            return Ok(contactDetailDto);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var contactDetails = await _contactDetailService.GetAll();

            if (!contactDetails.Any())
                return NotFound();

            var contactDetailsDto = contactDetails.Select(w => w.Adapt<ContactDetailDto>()).ToList();
            return Ok(contactDetailsDto);
        }

        [HttpGet("getAllByContactId")]
        public async Task<IActionResult> GetAllByContactId(int id)
        {
            var contactDetails = await _contactDetailService.GetAllByContactId(id);

            if (!contactDetails.Any())
                return NotFound();

            var contactDetailsDto = contactDetails.Select(w => w.Adapt<ContactDetailDto>()).ToList();
            return Ok(contactDetailsDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ContactDetailAddDto contactDetailAddDto)
        {
            var contactDetail = contactDetailAddDto.Adapt<ContactDetail>();
            await _contactDetailService.Add(contactDetail);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ContactDetailUpdateDto contactDetailUpdateDto)
        {
            var contactDetail = await _contactDetailService.GetById(contactDetailUpdateDto.Id);
            contactDetail = contactDetailUpdateDto.Adapt(contactDetail);
            await _contactDetailService.Update(contactDetail);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var contactDetail = await _contactDetailService.GetById(id);
            await _contactDetailService.Delete(contactDetail);
            return Ok();
        }
    }
}