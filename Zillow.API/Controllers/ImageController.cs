using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zillow.Core.Dto;
using Zillow.Servise.Servise.Image;

namespace Zillow.API.Controllers
{
    public class ImageController : BaseController
    {
        private IImageServise _imageService;
        public ImageController(IImageServise imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1)
        {
            var categories = _imageService.getAll(page);
            return Ok(GetRespons(categories));
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateImageDto dto)
        {
            _imageService.Create(dto);
            return Ok(GetRespons(null, "Done"));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateImageDto dto)
        {
            _imageService.Update(dto);
            return Ok(GetRespons());
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _imageService.Delete(Id);
            return Ok(GetRespons());
        }
    }
}
