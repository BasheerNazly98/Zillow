using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zillow.Core.Dto;
using Zillow.Servise.Servise.Category;

namespace Zillow.API.Controllers
{
    public class CategoryController : BaseController
    {
        private ICategoryServise _categoryService;
        public CategoryController(ICategoryServise categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll(int page=1)
        {
            var categories = _categoryService.getAll(page);
            return Ok(GetRespons(categories));
        }
        [HttpPost]
        public IActionResult Create([FromBody]CreateCategoryDto dto)
        {
            _categoryService.Create(dto);
            return Ok(GetRespons(null, "Done"));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateCategoryDto dto)
        {
            _categoryService.Update(dto);
            return Ok(GetRespons());
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _categoryService.Delete(Id);
            return Ok(GetRespons());
        }
    }
}
