using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.BannerQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly CreateBannerCommandHandlers _commandHandlers;
        private readonly GetBannerByIdQueryHandler _queryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;

        public BannerController(CreateBannerCommandHandlers commandHandlers, 
            GetBannerByIdQueryHandler queryHandler, 
            GetBannerQueryHandler getBannerQueryHandler, 
            RemoveBannerCommandHandler removeBannerCommandHandler, 
            UpdateBannerCommandHandler updateBannerCommandHandler)
        {
            _commandHandlers = commandHandlers;
            _queryHandler = queryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var value = await _getBannerQueryHandler.Handle();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BannerListById(int id)
        {
            var value = await _queryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBannerCommandHandler(CreateBannerCommand command)
        {
            await _commandHandlers.Handle(command);
            return Ok("Banner başarıyla oluşturuldu.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBannerCommandHandler(int id)
        {
            await _removeBannerCommandHandler.Handle(new RemoveBannerCommands(id));
            return Ok("Banner başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBannerCommandHandler(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handle(command);
            return Ok("Banner başarıyla güncellendi.");
        }
    }
}
