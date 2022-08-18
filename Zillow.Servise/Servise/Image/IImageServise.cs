using System;
using System.Collections.Generic;
using System.Text;
using Zillow.Core.Dto;
using Zillow.Core.ViewModel;

namespace Zillow.Servise.Servise.Image
{
    public interface IImageServise
    {
        PagingViewModel getAll(int page);
        void Create(CreateImageDto dto);
        void Delete(int id);
        void Update(UpdateImageDto dto);
    }
}
