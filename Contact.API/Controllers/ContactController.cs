using Contact.Business;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using Contact.API.Models;
using Contact.API.Models.ContactModels;

namespace Contact.API.Controllers
{
    [ApiController]
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _contactService;
        private readonly IContactDetailService _contactDetailService;


        public ContactController(ILogger<ContactController> logger, IContactService contactService, IContactDetailService contactDetailService)
        {
            _logger = logger;
            _contactService = contactService;
            _contactDetailService = contactDetailService;
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _contactService.GetById(id);

            if (contact == null)
                return NotFound();

            contact.ContactDetails = await _contactDetailService.GetAllByContactId(contact.Id);

            var contactDto = contact.Adapt<ContactDto>();
            return Ok(contactDto);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactService.GetAll();

            if (!contacts.Any())
                return NotFound();

            var contactsDto = contacts.Select(w => w.Adapt<ContactDto>()).ToList();
            return Ok(contactsDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ContactAddDto contactAddDto)
        {
            var contact = contactAddDto.Adapt<Entity.Contact>();
            await _contactService.Add(contact);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ContactUpdateDto contactUpdateDto)
        {
            var contact = await _contactService.GetById(contactUpdateDto.Id);
            contact = contactUpdateDto.Adapt(contact);
            await _contactService.Update(contact);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _contactService.GetById(id);
            await _contactService.Delete(contact);
            return Ok();
        }
    }
}