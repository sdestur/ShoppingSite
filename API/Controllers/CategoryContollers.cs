using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryContollers : ControllerBase
    {
        ICategoryService _categoryService;



        public CategoryContollers(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Kategori Ekeleme")]
        public IActionResult Add([FromQuery] CategoryDto category)
        {
            var result = _categoryService.Add(category);
            if (result.Success)
            {
                //if())


                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
