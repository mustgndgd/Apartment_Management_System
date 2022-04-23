using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Apartment.App.Business.DTO
{
    public class InvoiceTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
    }
}
