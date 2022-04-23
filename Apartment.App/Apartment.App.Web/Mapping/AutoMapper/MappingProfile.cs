using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Apartment.App.Business.DTO;
using Apartment.App.Domain.Entities;
using Apartment.App.Web.Models.HousingViewModels;
using AutoMapper;

namespace Apartment.App.Web.Mapping.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //ilk yer source ikinci yer target
            CreateMap<Floor, FloorDto>();
            //CreateMap< List<Floor>, List<FloorDto> >();
            CreateMap<Block, BlockDto>();
            CreateMap<BlockDto, Block>();
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<InvoiceType, InvoiceTypeDto>();
            CreateMap<HousingDto, Housing>();

        }
    }
}
