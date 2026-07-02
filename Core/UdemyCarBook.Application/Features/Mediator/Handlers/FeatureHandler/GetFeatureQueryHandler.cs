using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.FeatureQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FeatureResult;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandler
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResults> >
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResults>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetFeatureQueryResults
            {
                FeatureId=x.FeatureId,
                Name=x.Name
            }).ToList();
        }


    }
}
