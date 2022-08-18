using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zillow.Core.Dto;
using Zillow.Core.ViewModel;
using Zillow.Data;

namespace Zillow.Servise.Servise.Contract
{
    public class ContractServise : IContractServise
    {
        private ApplicationDbContext _DB;

        public ContractServise(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public PagingViewModel getAll(int page)
        {
            var pages = Math.Ceiling(_DB.Contracts.Count() / 10.0);

            if (page < 1 || page > pages)
            {
                page = 1;
            }
            var skip = (page - 1) * 10;
            var contract = _DB.Contracts.Include(x => x.realEstate).Include(x => x.customer).Select(
                  x => new ContractViewModel()
                  {
                      id = x.id,
                      contractType = x.contractType,                    
                      Price = x.Price,
                      customer = new CustomerViewModel()
                      {
                          Id = x.customer.id,
                          name = x.customer.name,
                          phone = x.customer.phone,
                          address  = new AddressViewModel()
                          {
                              id = x.customer.address.id,
                              cityName = x.customer.address.cityName,
                              countryName = x.customer.address.countryName
                          }

                      }
                  }
                  ).Skip(skip).Take(10).ToList();
                    var result = new PagingViewModel();
                    result.cureentPage = page;
                    result.numOfPages = (int)pages;
                    result.data = contract;
                    return result;
        }
        public void Create(CreateContractDto dto)
        {
            var contract = new Zillow.Data.Models.Contract();
            contract.contractType = dto.contractType;
            contract.customerId = dto.customerId;
            contract.Price = dto.Price;
            contract.realEstateId = dto.realEstateId;

            _DB.Contracts.Add(contract);
            _DB.SaveChanges();
        }

        public void Update(UpdateContractDto dto)
        {
            var contract = _DB.Contracts.SingleOrDefault(X => X.id == dto.id && !X.IsDelete);
            contract.contractType = dto.contractType;
            contract.customerId = dto.customerId;
            contract.Price = dto.Price;
            contract.realEstateId = dto.realEstateId;
            _DB.Contracts.Update(contract);
            _DB.SaveChanges();
        }
        public void Delete(int id)
        {
            var contract = _DB.Contracts.SingleOrDefault(X => X.id == id && !X.IsDelete);
            contract.IsDelete = true;
            _DB.Contracts.Update(contract);
            _DB.SaveChanges();
        }



    }
    }

