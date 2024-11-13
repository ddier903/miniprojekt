using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Core1;

public class Order
{
    public ObjectId OrderId { get; set; }
    public Listing Listing { get; set; }
    public DateTime OrderDate { get; set; }
}
