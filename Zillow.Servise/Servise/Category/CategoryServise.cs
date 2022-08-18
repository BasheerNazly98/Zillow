using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zillow.Core.Dto;
using Zillow.Core.ViewModel;
using Zillow.Data;

namespace Zillow.Servise.Servise.Category
{
    public class CategoryServise : ICategoryServise
    {
        private ApplicationDbContext _DB;

        public CategoryServise(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public PagingViewModel getAll(int page)
        {
            var pages = Math.Ceiling(_DB.Category.Count() / 10.0);

            if (page < 1 || page > pages)
            {
                page = 1;
            }
            var skip = (page - 1) * 10;
            var category = _DB.Category.Select(
                x => new CategoryViewModel()
                {
                    id = x.id,
                    Name = x.Name,
                    description = x.description
                }
                ).Skip(skip).Take(10).ToList();
            var result = new PagingViewModel();
            result.cureentPage = page;
            result.numOfPages = (int)pages;
            result.data = category;
            return result;
            
        }
        public void Create(CreateCategoryDto dto)
        {
            var category = new Zillow.Data.Models.Category();
            category.Name = dto.Name;
            category.description = dto.description;
            _DB.Category.Add(category);
            _DB.SaveChanges();
        }
        public void Update(UpdateCategoryDto dto)
        {
            var category = _DB.Category.SingleOrDefault(X => X.id == dto.id && !X.IsDelete);
            category.Name = dto.Name;
            category.description = dto.description;
            _DB.Category.Update(category);
            _DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _DB.Category.SingleOrDefault(X => X.id == id && !X.IsDelete);
            category.IsDelete = true;
            _DB.Category.Update(category);
            _DB.SaveChanges();
        }



    }
}
