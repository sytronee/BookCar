using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.FooterAddressCommand;
using UdemyCarBook.Application.Features.Mediator.Queries.FeatureQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.FooterAddressQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressContoller : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressContoller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFooterAddress()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddressById(int id)
        {
            var values = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("FooterAddress başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("FooterAddress başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAddress(RemoveFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("FooterAddress başarıyla silindi");

            //await _mediator.Send(new RemoveFooterAddressCommand(id));
            //return Ok("FooterAddress başarıyla silindi");
        }
    }
}
