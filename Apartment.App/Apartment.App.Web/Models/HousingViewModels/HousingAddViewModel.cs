using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Apartment.App.Business.DTO;
using Apartment.App.Domain.Entities.IdentityEntities;

namespace Apartment.App.Web.Models.HousingViewModels
{
    public class HousingAddViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Boş Mu?")]
        public bool IsEmpty { get; set; }
        [Display(Name = "Ev sahibi mi")]
        public bool IsHomeowner { get; set; }
        [Display(Name = "Kat numarasu")]
        public int FloorNumber { get; set; }
        [Display(Name = "Blok numrasu")]
        public int BlockNumber { get; set; }
        [Display(Name = "Daire Numarası")]
        public int ApartmentNumber { get; set; }
        [Display(Name = "Apartman Büyüklüğü")]
        public string ApartmentSizeInfo { get; set; }
        [Display(Name = "Ev Sahibi Kimlik Numarası")]
        public string HousingHirerTcIdentityNumber { get; set; }
    }

}
