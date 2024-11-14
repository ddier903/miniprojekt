using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;  
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 



namespace Core1
{
    public class Listing
    {
        public ObjectId ListingID { get; set; }
        [Required]
        public string Name { get; set; } = "NO NAME";
        [Required]
        public int Price { get; set; } = -12;
        public bool IsActive { get; set; } = true;
        [Required]
        public string Description { get; set; } = "desc";
        [Required]
        public DateTime ListingDate { get; set; } = DateTime.Now;
        [Required]
        public string Image { get; set; } = "img";
        [Required]
        public string CategoryName { get; set; } = "no cat";

      
        public ObjectId? UserId { get; set; }

    }
}
