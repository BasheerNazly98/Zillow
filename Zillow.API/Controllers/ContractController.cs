using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zillow.Core.Dto;
using Zillow.Servise.Servise.Contract;

namespace Zillow.API.Controllers
{
    public class ContractController : BaseController
    {
        private IContractServise _contractService;
        public ContractController(IContractServise contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public IActionResult GetAll(int page=1)
        {
            var categories = _contractService.getAll(page);
            return Ok(GetRespons(categories));
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] CreateContractDto dto)
        {
            _contractService.Create(dto);
            return Ok(GetRespons(null, "Done"));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateContractDto dto)
        {
            _contractService.Update(dto);
            return Ok(GetRespons());
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _contractService.Delete(Id);
            return Ok(GetRespons());
        }
    }
}
