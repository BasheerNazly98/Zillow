using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zillow.Core.Dto;
using Zillow.Core.ViewModel;
using Zillow.Data;
using Zillow.Data.Models;

namespace Zillow.Servise.Servise.Address
{
    public class AddressServise : IAddressServise
    {
        private ApplicationDbContext _DB;

        public AddressServise(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public PagingViewModel getAll(int page)
        {
            var pages = Math.Ceiling(_DB.Address.Count() / 10.0);
            
            if (page <1 || page > pages) {
                page = 1;
            }
            var skip = (page - 1) * 10;
            var address = _DB.Address.Select(
                x => new AddressViewModel()
                {
                    id = x.id,
                    cityName = x.cityName,
                    countryName = x.countryName
                }        
                ).Skip(skip).Take(10).ToList();
            var result = new PagingViewModel();
            result.cureentPage =page;
            result.numOfPages =(int)pages;
            result.data = address;
            return result;
        }
        public void Create(CreateAddressDto dto)
        {
            var address = new Zillow.Data.Models.Address();
            address.cityName = dto.cityName;
            address.countryName = dto.countryName;
            _DB.Address.Add(address);
            _DB.SaveChanges();
        }
        public void Update(UpdateAddressDto dto)
        {
            var address = _DB.Address.SingleOrDefault(X => X.id == dto.Id && !X.IsDelete);
            address.cityName = dto.cityName;
            address.countryName = dto.countryName;
            _DB.Address.Update(address);
            _DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var address = _DB.Address.SingleOrDefault(X => X.id == id && !X.IsDelete);
            address.IsDelete = true;
            _DB.Address.Update(address);
            _DB.SaveChanges();
        }



    }
}
