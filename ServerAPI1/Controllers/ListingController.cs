using System.Reflection;
using Core1;
using Microsoft.AspNetCore.Mvc;
using ServerAPI1.Repositories;


namespace ServerAPI1.Controllers;

    [ApiController]
    [Route("/Listing")]

    public class ListingController
    {
        ListingRepository repository;
        public ListingController()
        {
            repository = new ListingRepository();
        }

        [HttpGet]
        [Route("GetAllListings")]
        //Henter alle Listings fra repository:
        public IEnumerable<Listing> GetAllListings()
        {
            return (IEnumerable<Listing>)repository.GetAllActiveListings();
        }

        //Tilføjer ny Listing til repository:
        [HttpPost]
        [Route("AddListing")]
        public async Task AddListing(Listing listing)
        {

            await repository.AddListing(listing);

            //Mangler mere logik
        }
        [HttpGet]
        [Route("GetListingByCategory")]
        //Viser listings filtreret på category.
        public IEnumerable<Listing> GetListingByCategory(string category)
        {
            return (IEnumerable<Listing>)repository.GetListingByCategory(category);
        }
        [HttpGet]
        [Route("GetListingByPriceDesc")]
        //Viser lisings sorteret efter pris faldende.

        public IEnumerable<Listing> GetListingByPriceDescending()
        {
            return (IEnumerable<Listing>)repository.GetListingByPriceDescending();
        }
        [HttpGet]
        [Route("GetListingByPriceAsc")]
        //Viser listings sorteret efter pris stigende.
        public IEnumerable<Listing> GetListingByPriceAscending()
        {
            return (IEnumerable<Listing>)repository.GetListingByPriceAscending();
        }

        //Viser Listings filteret efter søgeord:

        [HttpGet]
        [Route("GetListingByUser")]

        //Viser Aktive listings for en specifik bruger:

        public IEnumerable<Listing> GetActiveListingsByUser(ObjectId userid)
        {
            return (IEnumerable<Listing>)repository.GetActiveListingsByUser(userid);
        }
    }

