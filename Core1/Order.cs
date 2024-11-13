using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core1;

public class Order
{
    public int UserId { get; set; }
    public int OrderId { get; set; }
    public int ListingId { get; set; }
    public DateTime OrderDate { get; set; }
    public int Price { get; set; }
}
