using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_CRUD.Models
{
    public class PaymentRecord
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("CardNumber")]
        public string CardNumber { get; set; }

        [BsonElement("CardOwnerName")]
        public string CardOwnerName { get; set; }

        [BsonElement("CardSecurityNumber")]
        public string CardSecurityNumber { get; set; }
        [BsonElement("CardLastUsableDate")]
        public string CardLastUsableDate { get; set; }

        [BsonElement("InvoiceId")]
        public string InvoiceId { get; set; }

        [BsonElement("InvoicePrice")]
        public string InvoicePrice { get; set; }
        [BsonElement("InvoiceOwnerTrIdentityNumber")]
        public string InvoiceOwnerTrIdentityNumber { get; set; }
    }
}
