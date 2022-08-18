using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zillow.Core.Dto;
using Zillow.Core.ViewModel;
using Zillow.Data;

namespace Zillow.Servise.Servise.Customer
{
    public class CustomerServise : ICustomerServise
    {
        private ApplicationDbContext _DB;

        public CustomerServise(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public PagingViewModel getAll(int page)
        {
            var pages = Math.Ceiling(_DB.Customers.Count() / 10.0);

            if (page < 1 || page > pages)
            {
                page = 1;
            }
            var skip = (page - 1) * 10;
            var customers = _DB.Customers.Include(x => x.address).Select(
                x => new CustomerViewModel()
                {
                    Id = x.id,
                    name = x.name,
                    phone = x.phone,
                    address = new AddressViewModel()
                    {
                        id = x.address.id,
                        cityName = x.address.cityName,
                        countryName = x.address.countryName
                    }
                }
                ).Skip(skip).Take(10).ToList();
            var result = new PagingViewModel();
            result.cureentPage = page;
            result.numOfPages = (int)pages;
            result.data = customers;
            return result;
        
    }
        public void Create(CreateCustomerDto dto)
        {
            var customer = new Zillow.Data.Models.Customer();
            customer.name = dto.name;
            customer.phone = dto.phone;
            customer.addressId = dto.addressId;

            _DB.Customers.Add(customer);
            _DB.SaveChanges();
        }
        
        public void Update(UpdateCustomerDto dto)
        {
            var customer = _DB.Customers.SingleOrDefault(X => X.id == dto.id && !X.IsDelete);
            customer.name = dto.name;
            customer.phone = dto.phone;
            customer.addressId = dto.addressId;
            _DB.Customers.Update(customer);
            _DB.SaveChanges();
        }
        
        public void Delete(int id)
        {
            var customer = _DB.Customers.SingleOrDefault(X => X.id == id && !X.IsDelete);
            customer.IsDelete = true;
            _DB.Customers.Update(customer);
            _DB.SaveChanges();
        }

    }
}
