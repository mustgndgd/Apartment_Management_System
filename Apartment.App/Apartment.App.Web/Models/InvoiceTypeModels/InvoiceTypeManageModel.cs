using System.ComponentModel.DataAnnotations;

namespace Apartment.App.Web.Models.InvoiceTypeModels
{
    public class InvoiceTypeManageModel
    {
        public int Id { get; set; }

        [Display(Name = "Fatura Tip İsmi" )]
        [Required(ErrorMessage = "Fatura Tipi Adı Boş Geçilemez")]
        public string Name { get; set; }
        [Display(Name = "Fatura Tipi Birimi")]
        [Required(ErrorMessage = "Fatura Tipi Birimi Boş Geçilemez")]
        public string Unit { get; set; }
    }
}
