using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Commands;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoriesService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoriesService, IMapper mapper)
        {
            _categoriesService = categoriesService;
            _mapper = mapper;
        }

        [HttpGet("{Code}")]
        public async Task<IActionResult> GetCategory(string Code)
        {
            var product = await _categoriesService.Get(Code);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCommand Category)
        {
            var result = await _categoriesService.CreateCategory(Category);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete("{Code}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] string Code)
        {
            var result = await _categoriesService.DeleteCategory(Code);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}