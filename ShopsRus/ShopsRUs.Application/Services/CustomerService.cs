using AutoMapper;
using ShopsRUs.Application.Interfaces;
using ShopsRUs.Application.Model;
using ShopsRUs.Core;
using ShopsRUs.Core.Entities;
using ShopsRUs.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        public CustomerService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomerModel> GetByIdAsync(int id)
        {
                var res = await _repository.CustomerRepository.GetByIdAsync(id);
                var modelRes= _mapper.Map<CustomerModel>(res);

                return modelRes;
          
        }
      
    }
}
