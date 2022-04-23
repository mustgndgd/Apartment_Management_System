using System;
using System.Collections.Generic;
using System.Text;

namespace Apartment.App.Business.DTO
{
    public class HousingDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public List<InvoiceDto> Invoices { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsHomeowner { get; set; }
      //  public FloorDto Floor { get; set; }
       // public int FloorId { get; set; }
        public int FloorNumber { get; set; }
      //  public int BlockId { get; set; }
        public int BlockNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public string ApartmentSizeInfo { get; set; }
    }
}
