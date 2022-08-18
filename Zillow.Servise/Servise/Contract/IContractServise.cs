using System;
using System.Collections.Generic;
using System.Text;
using Zillow.Core.Dto;
using Zillow.Core.ViewModel;

namespace Zillow.Servise.Servise.Contract
{
    public interface IContractServise
    {
        PagingViewModel getAll(int page);
        void Create(CreateContractDto dto);
        void Delete(int id);
        void Update(UpdateContractDto dto);
    }
}
