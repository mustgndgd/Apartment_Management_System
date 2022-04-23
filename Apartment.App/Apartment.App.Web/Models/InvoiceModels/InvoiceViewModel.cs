using System.Collections.Generic;
using Apartment.App.Business.DTO;
using Apartment.App.Web.Models.InvoiceModels;

namespace Apartment.App.Web.Models.InvoiceModels
{
    public class InvoiceViewModel
    {

        public List<InvoiceModel> Invoices { get; set; } = new List<InvoiceModel>();
        public bool isUserAdmin { get; set; }
    }
}
