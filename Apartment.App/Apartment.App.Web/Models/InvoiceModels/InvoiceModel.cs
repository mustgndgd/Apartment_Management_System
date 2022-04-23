using System;
using Apartment.App.Business.DTO;

namespace Apartment.App.Web.Models.InvoiceModels
{
    public class InvoiceModel
    {
        public InvoiceTypeDto invoiceType { get; set; } = new InvoiceTypeDto();

        public int Id { get; set; }
        public int housingId { get; set; }
        public string InvoiceOwnerTrIdentity { get; set; }
        public string InvoiceOwnerName { get; set; }
        public string housingAdress { get; set; }
        public bool IsSpended { get; set; }
        public int TotalDay { get; set; }
        public double InvoiceAmountOfUse { get; set; }
        public double InvoiceUnitPrice { get; set; }
        public double InvoicePrice { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastSpendDate { get; set; }
    }
}
