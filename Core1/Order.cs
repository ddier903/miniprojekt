﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
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
