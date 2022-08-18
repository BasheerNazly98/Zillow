using System;
using System.Collections.Generic;
using System.Text;
using Zillow.Core.Dto;
using Zillow.Core.ViewModel;

namespace Zillow.Servise.Servise.Category
{
    public interface ICategoryServise
    {
        PagingViewModel getAll(int page);
        void Create(CreateCategoryDto dto);
        void Delete(int id);
        void Update(UpdateCategoryDto dto);
    }
}
