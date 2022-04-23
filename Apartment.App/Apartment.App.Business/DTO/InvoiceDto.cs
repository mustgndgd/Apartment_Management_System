using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Apartment.App.Domain.Entities;

namespace Apartment.App.Business.DTO
{
    public class InvoiceDto
    {
        public int invoiceId { get; set; } 
        
        [Required]
        public InvoiceTypeDto invoiceType{ get; set; }
        public UserDto User { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastSpendDate { get; set; }
        public bool IsSpended { get; set; }
        public int TotalDay { get; set; }
        public int InvoiceAmountOfUse { get; set; }
        public int InvoicePrice { get; set; }

    }
}
