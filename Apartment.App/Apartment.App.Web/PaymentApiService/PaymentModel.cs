namespace Apartment.App.Web.PaymentApiService
{
    public class PaymentModel
    {
        public string cardNumber { get; set; }
        public string cardOwnerName { get; set; }
        public string cardSecurityNumber { get; set; }
        public string cardLastUsableDate { get; set; }
        public string invoiceId { get; set; }
        public string invoicePrice { get; set; }
        public string invoiceOwnerTrIdentityNumber { get; set; }
    }
}
