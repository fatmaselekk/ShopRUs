using ShopsRUs.Application.Interfaces;
using ShopsRUs.Application.Model;
using ShopsRUs.Core;
using ShopsRUs.Core.Entities;
using ShopsRUs.Core.Enum;
using ShopsRUs.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _repository;
        private readonly ICustomerService _customerService;
        private readonly IDiscountService _discountService;
        public InvoiceService(IUnitOfWork repository, ICustomerService customerService, IDiscountService discountService)
        {
            _repository = repository;
            _customerService = customerService;
            _discountService = discountService;
        }


        public async Task<InvoiceCalculateModel> GetCalculateInvoice(InvoiceRequestModel requestModel)
        {

            decimal discountTotalAmount = 0;
            decimal totalAmount = 0;
            decimal groceriesAmount = 0;
            InvoiceCalculateModel result = new InvoiceCalculateModel();
            var customerInfo = await _customerService.GetByIdAsync(requestModel.CustomerId);
            if (customerInfo != null)
            {
                var discount = await _discountService.GetByCustomerId(customerInfo.CustomerTypeId);
                foreach (var product in requestModel.ProductList)
                {
                    if (!product.IsGroceries)
                    {
                        totalAmount = (product.Price * product.Quantity);
                    }
                    else
                    {
                        groceriesAmount = product.Price * product.Quantity;
                    }

                }

                if (customerInfo.CustomerTypeId == (int)CustomerTypes.Employee || customerInfo.CustomerTypeId == (int)CustomerTypes.Affiliate || (customerInfo.CustomerTypeId == (int)CustomerTypes.Customer && calculateYear(customerInfo.CreatedDate)))
                {
                    discountTotalAmount = (totalAmount / 100) * discount.Percentage;
                }
                else
                {
                    var howMany = totalAmount / 100;

                    discountTotalAmount = (howMany * 5);
                }


            }


            result.TotalAmount = (totalAmount - discountTotalAmount)+groceriesAmount;

            return result;
        }

        private bool calculateYear(DateTime date)
        {
            return DateTime.Now.Year - date.Year >= 2 ? true : false;
        }


    }

}
