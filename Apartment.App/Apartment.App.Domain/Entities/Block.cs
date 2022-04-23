using System;
using System.Collections.Generic;
using System.Text;

namespace Apartment.App.Domain.Entities
{
    public class Block:BaseEntity
    {
        public int BlockNumber { get; set; }
        public string Name { get; set; }
    }
}
