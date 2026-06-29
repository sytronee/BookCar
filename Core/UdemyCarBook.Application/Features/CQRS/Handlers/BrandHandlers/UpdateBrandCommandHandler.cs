using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repoistory;

        public UpdateBrandCommandHandler(IRepository<Brand> repoistory)
        {
            _repoistory = repoistory;
        }
        public async Task handle(UpdateBrandCommands command)
        {
            var values = await _repoistory.GetByIDAsync(command.BrandID);
            values.Name = command.Name;
            await _repoistory.UpdateAsync(values);
        }
    }
}
