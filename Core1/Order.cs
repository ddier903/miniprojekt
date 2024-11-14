using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core1
{
    public class Order
    {
        public ObjectId UserId { get; set; }

        [Required]
        public ObjectId OrderId { get; set; }
        [Required]
        public ObjectId ListingId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int Price { get; set; }

    }
}
