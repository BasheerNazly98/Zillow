using System;
using System.Collections.Generic;
using System.Text;
using Zillow.Core.Dto;
using Zillow.Core.ViewModel;

namespace Zillow.Servise.Servise.Address
{
    public interface IAddressServise
    {
        PagingViewModel getAll(int page);
        void Create(CreateAddressDto dto);
        void Delete(int id);
        void Update(UpdateAddressDto dto);
    }
}
