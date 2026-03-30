using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApplication1.Data.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.Int32)]
        [BsonElement("productid")]
        public int ProductId { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement("productname")]
        [BsonRequired]
        public string ProductName { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.Decimal128)]
        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;
    }
}
