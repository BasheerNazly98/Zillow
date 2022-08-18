using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zillow.Core.Dto;
using Zillow.Servise.Servise.Customer;

namespace Zillow.API.Controllers
{
    public class CustomerController : BaseController
    {
        private ICustomerServise _customerService;
        public CustomerController(ICustomerServise customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAll(int page=1)
        {
            var categories = _customerService.getAll(page);
            return Ok(GetRespons(categories));
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerDto dto)
        {
            _customerService.Create(dto);
            return Ok(GetRespons(null, "Done"));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateCustomerDto dto)
        {
            _customerService.Update(dto);
            return Ok(GetRespons());
        }
       
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _customerService.Delete(Id);
            return Ok(GetRespons());
        }
    }
}
