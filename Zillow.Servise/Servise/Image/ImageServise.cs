using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zillow.Core.Dto;
using Zillow.Core.ViewModel;
using Zillow.Data;

namespace Zillow.Servise.Servise.Image
{
    public class ImageServise : IImageServise
    {
        private ApplicationDbContext _DB;

        public ImageServise(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public PagingViewModel getAll(int page)
        {
            var pages = Math.Ceiling(_DB.Images.Count() / 10.0);

            if (page < 1 || page > pages)
            {
                page = 1;
            }
            var skip = (page - 1) * 10;
            var Images = _DB.Images.Include(x => x.realEstate).Select(
                x => new ImageViewModel()
                {
                    id = x.id,
                    Path = x.Path,
                }
                ).Skip(skip).Take(10).ToList();
            var result = new PagingViewModel();
            result.cureentPage = page;
            result.numOfPages = (int)pages;
            result.data = Images;
            return result;

        }
        public void Create(CreateImageDto dto)
        {
            var image = new Zillow.Data.Models.Image();
            image.Path = dto.Path;
            image.realEstateId = dto.realEstateId;
            _DB.Images.Add(image);
            _DB.SaveChanges();
        }

        public void Update(UpdateImageDto dto)
        {
            var image = _DB.Images.SingleOrDefault(X => X.id == dto.id && !X.IsDelete);
            image.Path = dto.Path;
            image.realEstateId = dto.realEstateId;
            _DB.Images.Update(image);
            _DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var image = _DB.Images.SingleOrDefault(X => X.id == id && !X.IsDelete);
            image.IsDelete = true;
            _DB.Images.Update(image);
            _DB.SaveChanges();
        }
    }
}
