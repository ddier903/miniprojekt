using System.Reflection;
using Core1;
using Microsoft.AspNetCore.Mvc;
using ServerAPI1.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ServerAPI1.Controllers;

    [ApiController]
    [Route("api/[controller]")]

    public class ListingController : ControllerBase
    {
        ListingRepository repository;
        public ListingController()
        {
            repository = new ListingRepository();
        }

        [HttpGet]
        [Route("GetAllListings")]
        //Henter alle Listings fra repository:
        public async Task <IEnumerable<Listing>> GetAllListings()
        {
            return await repository.GetAllActiveListings();
        }

        //Tilføjer ny Listing til repository:
        [HttpPost]
        [Route("AddListing")]
        public async Task<IActionResult> AddListing(Listing listing)
        {

        await repository.AddListing(listing);
        return Ok();

    }

        [HttpGet]
        [Route("GetListingByCategory")]
        //Viser listings filtreret på category.
        public async Task <IEnumerable<Listing>> GetListingByCategory(string category)
        {
            return await repository.GetListingByCategory(category);
        }
        [HttpGet]
        [Route("GetListingByPriceDesc")]
        //Viser lisings sorteret efter pris faldende.

        public async Task <IEnumerable<Listing>> GetListingByPriceDescending()
        {
            return await repository.GetListingByPriceDescending();
        }
        [HttpGet]
        [Route("GetListingByPriceAsc")]
        //Viser listings sorteret efter pris stigende.
        public async Task <IEnumerable<Listing>> GetListingByPriceAscending()
        {
            return await repository.GetListingByPriceAscending();
        }

        //Viser Listings filteret efter søgeord:

        [HttpGet]
        [Route("GetListingByUser")]

        //Viser Aktive listings for en specifik bruger:

        public async Task <IEnumerable<Listing>> GetActiveListingsByUser(ObjectId userid)
        {
            return await repository.GetActiveListingsByUser(userid);
        }
    }

