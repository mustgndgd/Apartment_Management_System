using System;
using System.Collections.Generic;
using System.Text;

namespace Apartment.App.Business.DTO
{
    public class FloorDto
    {
        public int Id { get; set; }
        public int FloorNumber { get; set; }
        public int BlockId { get; set; }
        public int BlockNumber { get; set; }
        public int HousingCount { get; set; }
        public List<HousingDto> Housings { get; set; } = new List<HousingDto>();
    }
}
