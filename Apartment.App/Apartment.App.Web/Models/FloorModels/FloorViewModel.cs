using System.Collections.Generic;
using Apartment.App.Business.DTO;

namespace Apartment.App.Web.Models.FloorModels
{
    public class FloorViewModel
    {
        public List<FloorDto> Floors { get; set; } = new List<FloorDto>();
    }
}
