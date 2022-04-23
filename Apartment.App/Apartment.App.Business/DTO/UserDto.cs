using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Apartment.App.Business.DTO
{
    public class UserDto
    {
        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
        [Display(Name = "Mail")]
        public string Email { get; set; }
        [Display(Name = "Kimlik Numarası")]
        public string TrIdentityNumber { get; set; }
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Arabası Var Mı?")]
        public bool HasCar { get; set; }
        [Display(Name = "Araba Plakası")]
        public string CarPlateNumber { get; set; }
        public bool UserIsAdmin { get; set; }
       
    }
}
