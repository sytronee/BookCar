using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByIdQueryResult> handle(GetCarByIdQuery query)
        {
            var values = await _repository.GetByIDAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                BigImageUrl=values.BigImageUrl,
                CarID=values.CarID,
                BrandID=values.BrandID,
                CoverImageUrl=values.CoverImageUrl,
                Fuel = values.Fuel,
                Km = values.Km,
                Laggage = values.Laggage,
                Model = values.Model,
                Seat = values.Seat,
                Transmission = values.Transmission
            };
        }
    }
}
