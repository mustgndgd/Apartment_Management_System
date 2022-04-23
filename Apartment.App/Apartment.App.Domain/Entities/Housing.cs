using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Apartment.App.Domain.Entities.IdentityEntities;
using Apartment.App.Domain.Entities;

namespace Apartment.App.Domain.Entities
{
    public class Housing:BaseEntity
    {
        public User User { get; set; }
        public Floor Floor { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsHomeowner { get; set; }
        public int ApartmentNumber { get; set; }
        public string ApartmentSizeInfo { get; set; }
         
    }
}
