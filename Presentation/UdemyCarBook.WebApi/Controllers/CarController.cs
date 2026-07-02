    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;

        public CarController(CreateCarCommandHandler createCarCommandHandler, 
            GetCarByIdQueryHandler getCarByIdQueryHandler, 
            GetCarQueryHandler getCarQueryHandler, 
            RemoveCarCommandHandler removeCarCommandHandler, 
            UpdateCarCommandHandler updateCarCommandHandler,
            GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _getCarWithBrandQueryHandler= getCarWithBrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CarListById(int id)
        {
            var values = await _getCarByIdQueryHandler.handle(new GetCarByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Car başarıyla kaydedildi.");
        }
        [HttpDelete]
        public async Task<IActionResult> CarRemove(int id)
        {
            await _removeCarCommandHandler.handle(new RemoveCarCommand(id));
            return Ok("Car başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> CarUpdate(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Car başarıyla güncellendi.");
        }

        [HttpGet("GetCarWithBrand")]
        public IActionResult GetCarWithBrand()
        {
            var values = _getCarWithBrandQueryHandler.handle();
            return Ok(values);
        }
    }
}
