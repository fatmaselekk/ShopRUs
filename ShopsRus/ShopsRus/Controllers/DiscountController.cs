using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : Controller
    {

        //[HttpPost, Route("CalculateDiscount")]
        //public async Task<ActionResult<TotalDiscountResponse>> CalculateDiscount(InvoiceRequest request)
        //{
        //    _logger.LogInformation($"Customer Get Request: {request}");
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var response = await _invoiceService.CalculateDiscount(request);
        //    return Ok(response);
        //}
    }
}
