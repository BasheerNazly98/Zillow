using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zillow.Core.Dto;
using Zillow.Core.ViewModel;

namespace Zillow.Servise.Servise.RealEstate
{
    public interface IRealEstateServise
    {
        PagingViewModel getAll(int page);
        Task Create(CreateRealEstateDto dto);
        void Delete(int id);
        void Update(UpdateRealEstateDto dto);
    }
}
