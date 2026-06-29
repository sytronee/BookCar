using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.BrandQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly  CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;

        public BrandController(GetBrandByIdQueryHandler getBrandByIdQueryHandler, 
            CreateBrandCommandHandler createBrandCommandHandler, 
            GetBrandQueryHandler getBrandQueryHandler, 
            RemoveBrandCommandHandler removeBrandCommandHandler, 
            UpdateBrandCommandHandler updateBrandCommandHandler)
        {
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _createBrandCommandHandler = createBrandCommandHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _getBrandQueryHandler.handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BrandListById(int id)
        {
            var values = await _getBrandByIdQueryHandler.handle(new GetBrandByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommands command)
        {
            await _createBrandCommandHandler.Handle(command);
            return Ok("Brand başarıyla kaydedildi.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(int id) 
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommands(id));
            return Ok("Brand başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommands commands)
        {
            await _updateBrandCommandHandler.handle(commands);
            return Ok("Brand başarıyla güncellendi.");
        }
    }
}
