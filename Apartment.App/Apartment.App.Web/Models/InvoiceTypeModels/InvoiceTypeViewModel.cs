using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Apartment.App.Business.DTO;

namespace Apartment.App.Web.Models.InvoiceTypeModels
{
    public class InvoiceTypeViewModel
    {
        public List<InvoiceTypeDto> InvoiceTypes { get; set; } = new List<InvoiceTypeDto>();
    }
}
