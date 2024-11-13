using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace Core1;
public class Category
{
    public ObjectId CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}