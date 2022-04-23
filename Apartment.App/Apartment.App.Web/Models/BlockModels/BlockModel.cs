using System.Collections.Generic;
using Apartment.App.Business.DTO;

namespace Apartment.App.Web.Models.BlockModels
{
    public class BlockModel
    {
        public BlockDto block { get; set; } = new BlockDto();
        public bool blockHasHirer { get; set; }
        public List<FloorDto> floorsInBlokcs { get; set; } = new List<FloorDto>();

    }
}
