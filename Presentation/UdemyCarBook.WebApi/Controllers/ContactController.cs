using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.ContactQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly CreateContactHandler _createContactHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;

        public ContactController(CreateContactHandler createContactHandler,
            GetContactByIdQueryHandler getContactByIdQueryHandler,
            GetContactQueryHandler getContactQueryHandler,
            RemoveContactCommandHandler removeContactCommandHandler,
            UpdateContactCommandHandler updateContactCommandHandler)
        {
            _createContactHandler = createContactHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetContact()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var values = await _getContactByIdQueryHandler.handle(new GetContactByIdQuery(id));
            return Ok(values);
        } 
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactHandler.handle(command);
            return Ok("Contact başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
             await _updateContactCommandHandler.Handle(command);
            return Ok("Contact başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
           await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
           return Ok("Contact başarıyla silindi");
        }
    }
}
