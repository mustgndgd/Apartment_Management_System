using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Apartment.App.Domain.Entities.IdentityEntities;
using Apartment.App.Domain.Entities;

namespace Apartment.App.Domain.Entities
{
    public class Invoice:BaseEntity
    {
        public User user { get; set; }
        public Housing Housing { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastSpendDate { get; set; } 
        public bool IsSpended { get; set; }
        public int TotalDay { get; set; }
        public double InvoiceAmountOfUse { get; set; }
        public double InvoiceUnitPrice { get; set; }
        public double InvoicePrice { get; set; }
        public string InvoicePaymentRecordId { get; set; } 

    }
}
