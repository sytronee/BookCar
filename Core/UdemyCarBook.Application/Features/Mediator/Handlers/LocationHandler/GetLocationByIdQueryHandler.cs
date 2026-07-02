using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.AboutQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;
using UdemyCarBook.Application.Features.Mediator.Results.LocationResult;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.LocationHandler
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdResult>
    {
        private readonly IRepository<Locations> _repository;

        public GetLocationByIdQueryHandler(IRepository<Locations> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIDAsync(request.Id);
            return new GetLocationByIdResult
            {
                LocationID = values.LocationID,
                Name = values.Name,
            };
        }
    }
}
