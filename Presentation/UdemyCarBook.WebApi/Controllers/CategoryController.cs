using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.CategoryQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly GetCategoryByIdQueryHandler _GetCategoryByIdQueryHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly CreateCategoryHandler _createCategoryHandler;

        public CategoryController(GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, 
            RemoveCategoryCommandHandler removeCategoryHandler, 
            GetCategoryQueryHandler getCategoryQueryHandler, 
            UpdateCategoryCommandHandler updateCategoryCommandHandler, 
            CreateCategoryHandler createCategoryHandler)
        {
            _GetCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _removeCategoryHandler = removeCategoryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _createCategoryHandler = createCategoryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ListCategroy()
        {
            var values = await _getCategoryQueryHandler.handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> listByIdCategory(int id)
        {
            var values = await _GetCategoryByIdQueryHandler.handle(new GetCategoryByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command) 
        {
            await _createCategoryHandler.Handle(command);
            return Ok("Category başarıyla kaydedildi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.handle(command);
            return Ok("Category başarıyla kaydedildi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _removeCategoryHandler.handle(new RemoveCategoryCommand(id));
            return Ok("Category başarıyla silindi");
        }
    }
}
