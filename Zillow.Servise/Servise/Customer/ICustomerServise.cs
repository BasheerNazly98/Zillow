using System;
using System.Collections.Generic;
using System.Text;
using Zillow.Core.Dto;
using Zillow.Core.ViewModel;

namespace Zillow.Servise.Servise.Customer
{
    public interface ICustomerServise
    {
        PagingViewModel getAll(int page);
        void Create(CreateCustomerDto dto);
        void Delete(int id);
        void Update(UpdateCustomerDto dto);
    }
}
