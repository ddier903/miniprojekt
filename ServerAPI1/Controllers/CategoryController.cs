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
[Route("/Category")]
public class CategoryController : ControllerBase
{
    CategoryRepository repository;

    public CategoryController()
    {
        repository = new CategoryRepository();
    }

    // Henter alle kategorier
    [HttpGet]
    [Route("GetAllCategories")]
    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return await repository.GetAllCategories();
    }

    // Henter en kategori baseret på id
    [HttpGet]
    [Route("GetCategoryById/")]
    public async Task<ActionResult<Category>> GetCategoryById(ObjectId id)
    {
        var category = await repository.GetCategoryById(id);
        if (category == null)
        {
            return NotFound(); // Hvis kategori ikke findes, returneres NotFound (404)
        }
        return category;
    }

    // Henter en kategori baseret på navn
    [HttpGet]
    [Route("GetCategoryByName/")]
    public async Task<ActionResult<Category>> GetCategoryByName(string name)
    {
        var category = await repository.GetCategoryByName(name);
        if (category == null)
        {
            return NotFound(); // Hvis kategori ikke findes, returneres NotFound (404)
        }
        return category;
    }

    // Tilføjer en ny kategori
    [HttpPost]
    [Route("AddCategory")]
    public async Task<ActionResult> AddCategory([FromBody] Category category)
    {
        if (category == null)
        {
            return BadRequest("Invalid category data."); // Returnerer 400, hvis inputdata er ugyldige
        }

        await repository.AddCategory(category);
        return CreatedAtAction(nameof(GetCategoryById), new { id = category.CategoryId }, category); // Returnerer 201 med den nyoprettede kategori
    }

    // Opdaterer en kategori
    [HttpPut]
    [Route("UpdateCategory")]
    public async Task<ActionResult> UpdateCategory([FromBody] Category category)
    {
        if (category == null)
        {
            return BadRequest("Invalid category data.");
        }

        await repository.UpdateCategory(category);
        return NoContent(); // Returnerer 204, da opdatering ikke kræver returdata
    }

    // Sletter en kategori
    [HttpDelete]
    [Route("DeleteCategory/")]
    public async Task<ActionResult> DeleteCategory(ObjectId id)
    {
        var category = await repository.GetCategoryById(id);
        if (category == null)
        {
            return NotFound(); // Hvis kategori ikke findes, returneres NotFound (404)
        }

        await repository.DeleteCategory(id);
        return NoContent(); // Returnerer 204, da sletning ikke kræver returdata
    }
}
