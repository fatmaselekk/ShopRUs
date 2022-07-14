using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Application.Interfaces;
using ShopsRUs.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.API.Controllers
{
    [Route("api/invoice")]
    [ApiController]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController( IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceCalculateModel>> CalculateDiscount(InvoiceRequestModel request)
        {

            var response = await _invoiceService.GetCalculateInvoice(request);
            return Ok(response);
        }
    }
}
