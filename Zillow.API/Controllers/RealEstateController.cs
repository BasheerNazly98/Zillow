using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zillow.Core.Dto;
using Zillow.Servise.Servise.RealEstate;

namespace Zillow.API.Controllers
{
    public class RealEstateController : BaseController
    {
        private IRealEstateServise _realEstateService;
    public RealEstateController(IRealEstateServise realEstateService)
    {
            _realEstateService = realEstateService;
    }

    [HttpGet]
    public IActionResult GetAll(int page = 1)
    {
        var address = _realEstateService.getAll(page);
        return Ok(GetRespons(address));
    }
        [HttpPost]
        public IActionResult Create([FromForm] CreateRealEstateDto dto)
        {
            _realEstateService.Create(dto);
            return Ok(GetRespons(null, "Done"));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateRealEstateDto dto)
        {
            _realEstateService.Update(dto);
            return Ok(GetRespons());
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _realEstateService.Delete(Id);
            return Ok(GetRespons());
        }
    }
}
