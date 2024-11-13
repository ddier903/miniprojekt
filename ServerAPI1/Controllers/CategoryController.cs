using System.Reflection;
using Core1;
using Microsoft.AspNetCore.Mvc;
using ServerAPI1.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using 

namespace ServerAPI1.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository; // opretter et privat felt af typen ICategoryRepository. Ved at tildele readonly kan dette felt kun sættes i konstruktøren, hvilket sikrer, at den ikke ændres i løbet af controllerens levetid.

        public CategoryController(ICategoryRepository categoryRepository) // Dette giver controlleren adgang til repository-metoder, som bruges til at håndtere data for Kategori.
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAllCategories() // Definerer en metode, der returnerer alle kategorier. ActionResult betyder, at metoden returnerer en HTTP-respons med data (her en liste af Kategori objekter).
        {
            return Ok(_categoryRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(int id) // En metode, der henter en enkelt Kategori baseret på id.
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound(); // Hvis ingen kategori findes for dette id, returneres en HTTP 404 Not Found-respons.
            }

            return Ok(category); // Hvis kategorien findes, returneres den med en HTTP 200 OK-respons.
            {

            }

        }

        [HttpPost]
        public ActionResult<Category> AddCategory(Category category)
        {
            _categoryRepository.add(category); //  Tilføjer den nye kategori til repository.
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public ActionResult<Category> UpdateCategory(int id, Category category) // Denne metode opdater en eksisterende kategori
        {
            var existingCategory = _categoryRepository.GetById(id); // tjekker om kategorien med den angivne id findes
            if (existingCategory == null)
            {
                return NotFound();
            }
            category.Id = existingCategory.Id; // sikrer at id på kategori-objektet ikke ændres under opdatering 
            _categoryRepository.update(category); // opdater kategorien i repository
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id) // En metode til at slette en kategori baseret på id
        {
            var category = _categoryRepository.GetById(id); // Tjekker om kategorien findes
            if (category == null)
            {
                return NotFound();
            }

            _categoryRepository.delete(id); // sletter kategorien fra repository 
            return NoContent();
        }
    }
