using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommand;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.AboutQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly GetAboutByIdQueryHandlers _getAboutByIdQueryHandlers;
        private readonly GetAboutQueryHandlers _getAboutQueryHandlers;
        private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;

        public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, 
            GetAboutByIdQueryHandlers getAboutByIdQueryHandlers, 
            GetAboutQueryHandlers getAboutQueryHandlers, 
            RemoveAboutCommandHandler removeAboutCommandHandler, 
            UpdateAboutCommandHandler updateAboutCommandHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _getAboutByIdQueryHandlers = getAboutByIdQueryHandlers;
            _getAboutQueryHandlers = getAboutQueryHandlers;
            _removeAboutCommandHandler = removeAboutCommandHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandlers.Handle();
            return Ok(values);   

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AboutListById(int id)
        {
            var values = await _getAboutByIdQueryHandlers.Handle(new GetAboutByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAboutCommandHandler(CreateAboutCommand command)
        {
            await _createAboutCommandHandler.Handle(command);
            return Ok("Hakkında bilgisi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAboutCommandHandler(int id)
        {
            await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Hakkında Bilgisi başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAboutCommandHandler(UpdateAboutCommand command)
        {
            await _updateAboutCommandHandler.Handle(command);
            return Ok("Hakkında bilgisi başarıyla güncellendi");
        }

    }
}
