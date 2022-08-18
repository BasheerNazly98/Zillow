using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Core.Dto;
using Zillow.Core.ViewModel;

namespace Zillow.Servise.Servise.Users
{
    public interface IUserService
    {
        PagingViewModel getAll(int page);
        Task Create(CreateUserDto dto);
        void Delete(int id);
        void Update(UpdateUserDto dto);

    }
}
