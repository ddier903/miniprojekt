using System.Reflection;
using Core1;
using Microsoft.AspNetCore.Mvc;
using ServerAPI1.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerAPI1.Controllers;

[ApiController]
[Route("/Order")]

public class OrderController : ControllerBase
{
    private readonly OrderRepository repository;

    public OrderController()
    {
        repository = new OrderRepository();
    }

    // Henter købshistorikken for en specifik bruger
    [HttpGet]
    [Route("GetPurchaseHistory/")]
    public async Task<IActionResult> GetPurchaseHistory(ObjectId userId)
    {
        var purchaseHistory = await repository.GetPurchaseHistory(userId);
        return Ok(purchaseHistory);
    }

    // Henter samlet antal køb for en bruger
    [HttpGet]
    [Route("GetTotalPurchasesCount/")]
    public async Task<IActionResult> GetTotalPurchasesCount(ObjectId userId)
    {
        var totalPurchases = await repository.GetTotalPurchasesCount(userId);
        return Ok(totalPurchases);
    }

    // Sletter en ordre baseret på OrderId
    [HttpDelete]
    [Route("DeleteOrder/")]
    public async Task<IActionResult> DeleteOrder(ObjectId orderId)
    {
        try
        {
            await repository.DeleteOrder(orderId);
            return NoContent(); // 204 No Content betyder succes uden indhold
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Order with ID {orderId} not found."); // Returnerer 404 hvis ordren ikke blev fundet
        }
    }
}
