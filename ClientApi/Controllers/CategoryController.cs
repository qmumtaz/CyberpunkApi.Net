using ClientApi.Dtos;
using ClientApi.Services;
using ClientApi.Services.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace ClientApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService) 
        => _categoryService = categoryService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
       var categories = await _categoryService.GetAll();

        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CategoryDto category)
    {
        await _categoryService.CreateCategory(new Categories() { Name = category.Name });

        return Ok();
    }
}
