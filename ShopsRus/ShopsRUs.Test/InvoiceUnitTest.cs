using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using ShopsRUs.API.Controllers;
using ShopsRUs.Application.Interfaces;
using ShopsRUs.Application.Model;
using ShopsRUs.Application.Services;
using ShopsRUs.Core;
using ShopsRUs.Core.Entities;
using ShopsRUs.Core.Enum;
using ShopsRUs.Domain.UnitOfWork;
using ShopsRUs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ShopsRUs.Test
{
    public class InvoiceUnitTest
    {
        Mock<IInvoiceService> mock = new Mock<IInvoiceService>();
        Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
        Mock<ICustomerService> customerService = new Mock<ICustomerService>();
        Mock<IDiscountService> discountService = new Mock<IDiscountService>();
        Mock<IMapper> mockMapper = new Mock<IMapper>();

        InvoiceRequestModel invoiceDto = new InvoiceRequestModel()
        {
            CustomerId = 1,
            ProductList = new List<InvoiceProductRequestModel>()
                            {
                                new InvoiceProductRequestModel()
                                {
                                    Id = 1,
                                    Price = 150,
                                    Quantity = 2,
                                    IsGroceries = false,
                                }
                            }
        };

        CustomerModel customer = new CustomerModel()
        {
            Id = 1,
            CreatedDate = new DateTime(2018, 7, 23, 08, 20, 10),
            FirstName = "Test",
            LastName = "Test2",
            Email = "test@test.com",
            CustomerTypeId = 1
        };



        [Test]
        public async Task IsEmployeeTest()
        {

            var discount = new DiscountModel()
            {
                Percentage = 30
            };


            setImplementService(discount);


            var _sut = new InvoiceService(unitOfWorkMock.Object, customerService.Object, discountService.Object);

            var returnedCustomer = await _sut.GetCalculateInvoice(invoiceDto);


            Assert.AreEqual(returnedCustomer.TotalAmount, 210);

        }

        [Test]
        public async Task IsAffiliateTest()
        {


            var discount = new DiscountModel()
            {
                Percentage = 10
            };


            setImplementService(discount);


            var _sut = new InvoiceService(unitOfWorkMock.Object, customerService.Object, discountService.Object);

            var returnedCustomer = await _sut.GetCalculateInvoice(invoiceDto);


            Assert.AreEqual(returnedCustomer.TotalAmount, 270);

        }

        [Test]
        public async Task IsCustomerOverTwoYearTest()
        {


            var discount = new DiscountModel()
            {
                Percentage = 5
            };

            setImplementService(discount);


            var _sut = new InvoiceService(unitOfWorkMock.Object, customerService.Object, discountService.Object);

            var returnedCustomer = await _sut.GetCalculateInvoice(invoiceDto);


            Assert.AreEqual(returnedCustomer.TotalAmount, 285);

        }

        [Test]
        public async Task IsCustomerDontOverTwoYearTest()
        {

            CustomerModel customer = new CustomerModel()
            {
                Id = 1,
                CreatedDate = new DateTime(2022, 7, 23, 08, 20, 10),
                FirstName = "Test",
                LastName = "Test2",
                Email = "test@test.com",
                CustomerTypeId = 1
            };

            var discount = new DiscountModel()
            {
                Percentage = 5
            };

            ICustomerService customerservice = new CustomerService(unitOfWorkMock.Object, mockMapper.Object);

            customerService.Setup(l => l.GetByIdAsync(invoiceDto.CustomerId)).ReturnsAsync(customer);

            var discountservice = new DiscountService(unitOfWorkMock.Object, mockMapper.Object);

            discountService.Setup(l => l.GetByCustomerId(invoiceDto.CustomerId)).ReturnsAsync(discount);



            var _sut = new InvoiceService(unitOfWorkMock.Object, customerService.Object, discountService.Object);

            var returnedCustomer = await _sut.GetCalculateInvoice(invoiceDto);


            Assert.AreEqual(returnedCustomer.TotalAmount, 285);

        }

        [Test]
        public async Task CalculateGroceriesTest()
        {
            InvoiceRequestModel invoiceDto = new InvoiceRequestModel()
            {
                CustomerId = 1,
                ProductList = new List<InvoiceProductRequestModel>()
                            {
                                new InvoiceProductRequestModel()
                                {
                                    Id = 1,
                                    Price = 150,
                                    Quantity = 2,
                                    IsGroceries = true,
                                }
                            }
            };
            
            var discount = new DiscountModel()
            {
                Percentage = 5
            };


            setImplementService(discount);


            var _sut = new InvoiceService(unitOfWorkMock.Object, customerService.Object, discountService.Object);

            var returnedCustomer = await _sut.GetCalculateInvoice(invoiceDto);


            Assert.AreEqual(returnedCustomer.TotalAmount, 300);

        }


        private void setImplementService(DiscountModel discount)
        {
            ICustomerService customerservice = new CustomerService(unitOfWorkMock.Object, mockMapper.Object);

            customerService.Setup(l => l.GetByIdAsync(invoiceDto.CustomerId)).ReturnsAsync(customer);

            var discountservice = new DiscountService(unitOfWorkMock.Object, mockMapper.Object);

            discountService.Setup(l => l.GetByCustomerId(invoiceDto.CustomerId)).ReturnsAsync(discount);

        }

    }
}