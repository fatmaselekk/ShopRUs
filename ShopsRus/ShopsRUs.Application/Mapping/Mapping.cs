using AutoMapper;
using ShopsRUs.Application.Model;
using ShopsRUs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Application.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<Discount, DiscountModel>().ReverseMap();

        }
    }
}
