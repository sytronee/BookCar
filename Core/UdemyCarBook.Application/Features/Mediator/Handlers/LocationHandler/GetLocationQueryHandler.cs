using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;
using UdemyCarBook.Application.Features.Mediator.Results.LocationResult;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.LocationHandler
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationResult>>
    {
        private readonly IRepository<Locations> _repository;

        public GetLocationQueryHandler(IRepository<Locations> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetLocationResult
            {
                LocationID = x.LocationID,
                Name = x.Name,
            }).ToList();
        }
    }
}
