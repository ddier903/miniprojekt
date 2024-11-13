using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using miniprojekt.Core1;

namespace miniprojekt.Repositories;


// Opretter Order interface og definer CRUD metoder for Order klassen
public interface IOrderRepository
{
    IEnumerable<Order> GetAll();
    Order GetById(int id);
    void Add(Order order);
    void Update(Order order);
    void Delete(Order order);
}
