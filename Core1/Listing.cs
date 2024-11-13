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
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public bool IsActive { get; set; } = true;
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime ListingDate { get; set; } = DateTime.Now;
        [Required]
        public string Image { get; set; }
        [Required]
        public string CategoryName { get; set; }

        [Required]
        public ObjectId UserId { get; set; }

    }
}
