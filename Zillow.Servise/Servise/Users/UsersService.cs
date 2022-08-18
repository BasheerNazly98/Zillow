using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Core.Dto;
using Zillow.Core.ViewModel;
using Zillow.Data;

namespace Zillow.Servise.Servise.Users
{
    public class UsersService : IUserService
    {
        private ApplicationDbContext _DB;

        public UsersService(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public PagingViewModel getAll(int page)
        {
            var pages = Math.Ceiling(_DB.Users.Count() / 10.0);

            if (page < 1 || page > pages)
            {
                page = 1;
            }
            var skip = (page - 1) * 10;
            var users = _DB.Users.Select(
                x => new UsersViewModel()
                {
                    id = x.Id,
                    email = x.Email,
                    firstName = x.UserName,
                    lastName = x.UserName,
                    password = x.PasswordHash,
                    phoneNumber= x.PhoneNumber
                    
                }
                ).Skip(skip).Take(10).ToList();
            var result = new PagingViewModel();
            result.cureentPage = page;
            result.numOfPages = (int)pages;
            result.data = users;
            return result;
        }
        public void Create(CreateUserDto dto)
        {
            var user = new Data.Models.Users();
            user.email = dto.email;
            user.firstName = dto.firstName;
            user.lastName = dto.lastName;
            user.password = dto.password;
            user.phoneNumber = dto.phoneNumber;
            user.IsDelete = false;
            _DB.Users.Add(user);
            _DB.SaveChanges();
        }
        public void Update(UpdateUserDto dto)
        {
           /* var user = _DB.Users.SingleOrDefault(X => X.Id == Convert.ToString(id));
            user.id = dto.id;
            user.email = dto.email;
            user.firstName = dto.firstName;
            user.lastName = dto.lastName;
            user.password = dto.password;
            user.phoneNumber = dto.phoneNumber;
            _DB.Address.Update(user);
            _DB.SaveChanges();*/
        }

        public void Delete(int id)
        {
           /* var user = _DB.Users.SingleOrDefault(X => X.Id == Convert.ToString(id));
            user.IsDelete = true;
            _DB.Address.Update(user);
            _DB.SaveChanges();*/
        }

        Task IUserService.Create(CreateUserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
