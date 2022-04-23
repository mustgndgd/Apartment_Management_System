using System.ComponentModel.DataAnnotations;

namespace Apartment.App.Web.Models.InvoiceModels
{
    public class InvoicePayViewModel
    {
        public int InvoiceId { get; set; }
        [Display(Name = "Fatura Sahibi TC Kimlik Numarası")]
        public string InvoiceOwnerTcIdentityNumber { get; set; }
        [Display(Name = "Fatura Sahibi Adı Soyad")]
        public string InvoiceOwnerFullName { get; set; }
        [Display(Name = "Fatura Adresi")]
        public string InvoiceAddress { get; set; }
        [Display(Name = "Fatura Toplam Ücret")]
        public string InvoicePrice { get; set; }
        [Display(Name = "Fatura Detayı")]
        public string InvoiceDetail { get; set; }

        [Display(Name = "Kredi Kartı Ön Yüzündeki Numarayı Giriniz.")]
        [Required(ErrorMessage = "Kredi Kartı Numarasını Giriniz.")]
        [RegularExpression("^(\\d{4}-){3}\\d{4}$|^(\\d{4} ){3}\\d{4}$|^\\d{16}$", ErrorMessage = "Hatalı Giriş !! Kredi Kartı Numarasını Doğru Giriniz.")]
        public string CreditCardNumber { get; set; }
        [Display(Name = "Kredi Kartı Üzerinde Yazan İsminiz")]
        [Required(ErrorMessage = "Kredi Kartı Üzerinde Yazan İsminizi Giriniz.")]
        [DataType(DataType.Text)]
        public string CreditCardOwnerName { get; set; }
        [Display(Name = "Kartınızın Arka Yüzündeki Güvenlik Kodunu Giriniz.")]
        [Required(ErrorMessage = "Kartınızın Arka Yüzündeki Güvenlik Kodunu Giriniz.")]
        [RegularExpression(pattern: "^[0-9]{3}$", ErrorMessage = "Hatalı Giriş !! Kartınızın Arka Yüzündeki Güvenlik Kodunu Doğru Giriniz.")]
        public string CreditCardSecurtiyNumber { get; set; }

        public int CreditCardLastUseableDateMonth { get; set; }
        public int CreditCardLastUseableDateYear { get; set; }

    }
}
