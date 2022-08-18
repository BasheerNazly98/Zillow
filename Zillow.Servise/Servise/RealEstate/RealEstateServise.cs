using CMS.Service.Files;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zillow.Core.Dto;
using Zillow.Core.ViewModel;
using Zillow.Data;

namespace Zillow.Servise.Servise.RealEstate
{
    public class RealEstateServise : IRealEstateServise
    {
        private ApplicationDbContext _DB;
        private IFileService _fileService;

        public RealEstateServise(ApplicationDbContext DB, IFileService fileService)
        {
            _DB = DB;
            _fileService = fileService;
        }
        public PagingViewModel getAll(int page)
        {
            var pages = Math.Ceiling(_DB.RealEstates.Count() / 10.0);

            if (page < 1 || page > pages)
            {
                page = 1;
            }
            var skip = (page - 1) * 10;
            var realEstates = _DB.RealEstates.Include(x => x.images).Include(x => x.address).Include(x => x.category).Include(x => x.contracts).Select(
                x => new RealEstateViewModel()
                {
                    id = x.id,
                    Name = x.Name,
                    Description = x.Description,
                    address = new AddressViewModel()
                    {
                        id = x.address.id,
                        cityName = x.address.cityName,
                        countryName = x.address.countryName
                    },
                    category = new CategoryViewModel()
                    {
                        id = x.address.id,
                        Name = x.category.Name,
                        description = x.category.description
                    },
                    contracts = x.contracts.Select(
                    c => new ContractViewModel()
                    {
                        id = c.id,
                        contractType = c.contractType,
                        Price = c.Price,
                        customer = new CustomerViewModel()
                    {
                        Id = c.customer.id,
                        name = c.customer.name,
                        phone = c.customer.phone,
                        address = new AddressViewModel()
                        {
                            id = c.customer.address.id,
                            cityName = c.customer.address.cityName,
                            countryName = c.customer.address.countryName
                        }

                    }
                    
                }).ToList()
                ,
                    images = x.images.Select(x => x.Path).ToList()
                }
                ).Skip(skip).Take(10).ToList();
            var result = new PagingViewModel();
            result.cureentPage = page;
            result.numOfPages = (int)pages;
            result.data = realEstates;
            return result;

        }
        
        public async System.Threading.Tasks.Task Create(CreateRealEstateDto dto)
        {
            var realEstate = new Data.Models.RealEstate();
            realEstate.Name = dto.Name;
            realEstate.Description = dto.Description;
            realEstate.addressId = dto.addressId;
            realEstate.categoryId = dto.categoryId;
            _DB.RealEstates.Add(realEstate);
          
            foreach (var img in dto.images) {
                var imgname = await _fileService.SaveFile(img,"images");
                var image = new Data.Models.Image();
                image.realEstateId = realEstate.id;
                image.Path = imgname;
                _DB.Images.Add(image);
              
            }
            _DB.SaveChanges();

        }

        public void Update(UpdateRealEstateDto dto)
        {
            var realEstate = _DB.RealEstates.SingleOrDefault(X => X.id == dto.id && !X.IsDelete);
            realEstate.Name = dto.Name;
            realEstate.Description = dto.Description;
            realEstate.addressId = dto.addressId;
            realEstate.categoryId = dto.categoryId;
            _DB.RealEstates.Update(realEstate);
            _DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var realEstate = _DB.RealEstates.SingleOrDefault(X => X.id == id && !X.IsDelete);
            realEstate.IsDelete = true;
            _DB.RealEstates.Update(realEstate);
            _DB.SaveChanges();
        }
    }
}
