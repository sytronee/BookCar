using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.FooterAddressCommand;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandler
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            //await _repository.UpdateAsync(new FooterAddress
            //{
            //    Address = request.Address,
            //    Description = request.Description,
            //    Email = request.Email,
            //    Phone = request.Phone,
            //});

            var values = await _repository.GetByIDAsync(request.FooterAddressID);
            values.Phone = request.Phone;
            values.Description = request.Description;
            values.Email = request.Email;
            values.Address = request.Address;
            await _repository.UpdateAsync(values);
        }
    }
}
