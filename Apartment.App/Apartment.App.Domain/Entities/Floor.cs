using System;
using System.Collections.Generic;
using System.Text;

namespace Apartment.App.Domain.Entities
{
    public class Floor:BaseEntity
    {
        public Block Block { get; set; }
        public int FloorNumber { get; set; }
    }
}
