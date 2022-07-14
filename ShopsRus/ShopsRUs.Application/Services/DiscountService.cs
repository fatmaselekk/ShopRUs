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
    public class DiscountService : IDiscountService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        public DiscountService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DiscountModel> GetByCustomerId(int id)
        {
            var res = await _repository.DiscountRepository.GetByCustomerId(id);

            var modelRes = _mapper.Map<DiscountModel>(res);
            return modelRes;



        }


    }
}
