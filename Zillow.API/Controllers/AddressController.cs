using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zillow.Core.Dto;
using Zillow.Servise.Servise.Address;

namespace Zillow.API.Controllers
{
    public class AddressController : BaseController
    {
        private IAddressServise _addressService;
        public AddressController(IAddressServise addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IActionResult GetAll(int page=1)
        {
            var address = _addressService.getAll(page);
            return Ok(GetRespons(address));
        }
        [HttpPost]
        public IActionResult Create([FromBody]CreateAddressDto dto)
        {
            _addressService.Create(dto);
            return Ok(GetRespons(null,"Done"));
        }

        [HttpPut]
        public IActionResult Update([FromBody]UpdateAddressDto dto)
        {
            _addressService.Update(dto);
            return Ok(GetRespons());
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _addressService.Delete(Id);
            return Ok(GetRespons());
        }
    }
}
