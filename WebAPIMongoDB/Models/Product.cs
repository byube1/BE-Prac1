using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPIMongoDB.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("price")]
        public decimal Price { get; set; }
        [BsonElement("catelogy")]
        public string Category { get; set; }
        [BsonElement("dateCreate")]
        public DateTime DateCreate { get; set; }
        [BsonElement("img")]
        public string Img { get; set; }

    }
}
