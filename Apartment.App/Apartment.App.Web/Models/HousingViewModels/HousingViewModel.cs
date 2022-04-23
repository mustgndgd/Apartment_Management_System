using System.Collections.Generic;
using Apartment.App.Business.DTO;
using Apartment.App.Domain.Entities;
using Apartment.App.Domain.Entities.IdentityEntities;
using Apartment.App.Web.Models.UserViewModels;

namespace Apartment.App.Web.Models.HousingViewModels
{
    public class HousingViewModel
    {
        public bool isUserAdmin { get; set; }
        public List<HousingDto> HousingList { get; set; } = new List<HousingDto>();
        public UserViewModel User { get; set; } = new UserViewModel();
        public bool IsEmpty { get; set; }
        public bool IsHomeowner { get; set; }
        public int BlokNumber { get; set; }
        public int FloorNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public string ApartmentSizeInfo { get; set; }
        
    }
}
