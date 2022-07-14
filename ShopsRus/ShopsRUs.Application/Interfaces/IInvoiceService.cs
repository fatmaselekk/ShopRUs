using ShopsRUs.Application.Model;
using ShopsRUs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Application.Interfaces
{
    public interface IInvoiceService
    {
        Task<InvoiceCalculateModel> GetCalculateInvoice(InvoiceRequestModel requestModel);
    }
}
