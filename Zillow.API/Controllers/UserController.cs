using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zillow.Core.Dto;
using Zillow.Servise.Servise.Users;

namespace Zillow.API.Controllers
{
    public class UserController : BaseController
    {
        private IUserService _usersService;
        public UserController(IUserService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1)
        {
            var address = _usersService.getAll(page);
            return Ok(GetRespons(address));
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateUserDto dto)
        {
            _usersService.Create(dto);
            return Ok(GetRespons(null, "Done"));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateUserDto dto)
        {
            _usersService.Update(dto);
            return Ok(GetRespons());
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _usersService.Delete(Id);
            return Ok(GetRespons());
        }
    }
}
