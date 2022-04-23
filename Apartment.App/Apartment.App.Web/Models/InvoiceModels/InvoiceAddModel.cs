using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Apartment.App.Business.DTO;
using Microsoft.VisualBasic.CompilerServices;

namespace Apartment.App.Web.Models.InvoiceModels
{
    public class InvoiceAddModel
    {
        [Required]
        public int housingId { get; set; }
        [Required]
        [Display(Name = "Adresi")]
        public string housingAddress { get; set; }
        [Required]
        [Display(Name = "Fatura Sahibi")]
        public string housingOwner { get; set; }
        [Required]
        [Display(Name = "Fatura Tipi")]
        public int InvoiceTypeId { get; set; }
        [Required]

        [Display(Name = "Fatura Sahibi TC Numarası")]
        public string InvoiceOwnerTrIdentity { get; set; }
        [Required]
        [Display(Name = "Kullanım Yapılan Gün")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Geçerli bir gün giriniz")]
        public int TotalDay { get; set; }
        [Required]
        [Display(Name = "Kullanım Miktarı")]
        [RegularExpression("(?!^0*$)(?!^0*\\.0*$)^\\d{1,5}(\\.\\d{1,3})?$", ErrorMessage = "Geçerli bir sayı giriniz Örn: 10.00")] 
        public string InvoiceAmountOfUse { get; set; }
        [Required]
        [Display(Name = "Kullanım Birim Fiyatı")]
        [RegularExpression("(?!^0*$)(?!^0*\\.0*$)^\\d{1,5}(\\.\\d{1,3})?$", ErrorMessage = "Geçerli bir sayı giriniz Örn: 10.00")]
        public string InvoiceUnitPrice { get; set; }
        [Required]
        [Display(Name = "Toplam Tutar")]
        public string InvoicePrice { get; set; }
  
    }
}
