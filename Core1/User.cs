﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core1
{
    public class User
    {
        public ObjectId UserID { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        private string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public List<Listing> Listings { get; set; } = new List<Listing>();
        public List<Order> Orders { get; set; } = new List<Order>();

        public User(string username, string password, string firstname, string lastname, string email)
        {
            UserName = username;
            Password = password;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public void AddListing(Listing listing)
        {
            Listings.Add(listing);
        }
    }
}
