using System.Collections.Generic;
using Apartment.App.Business.DTO;

namespace Apartment.App.Web.Models.BlockModels
{
    public class BlockViewModel
    {
        public List<BlockModel> Blocks { get; set; } = new List<BlockModel>();
    }
}
