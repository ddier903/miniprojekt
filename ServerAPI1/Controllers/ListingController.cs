using System.Reflection;
using Core1;
using ServerAPI1.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerAPI1.Controllers
{
    public class ListingController
    {
        ListingRepository repository;
        public ListingController()
        {
            repository = new ListingRepository();
        }

        //Henter alle Listings fra repository:
        public IEnumerable<Listing> GetAllListings()
        {
            return (IEnumerable<Listing>)repository.GetAllActiveListings();
        }

        //Tilføjer ny Listing til repository:
        public async Task AddListing(Listing listing)
        {

            await repository.AddListing(listing);

            //Mangler mere logik
        }

        //Viser listings filtreret på category.
        public IEnumerable<Listing> GetListingByCategory(string category)
        {
            return (IEnumerable<Listing>)repository.GetListingByCategory(category);
        }

        //Viser lisings sorteret efter pris faldende.

        public IEnumerable<Listing> GetListingByPriceDescending()
        {
            return (IEnumerable<Listing>)repository.GetListingByPriceDescending();
        }

        //Viser listings sorteret efter pris stigende.
        public IEnumerable<Listing> GetListingByPriceAscending()
        {
            return (IEnumerable<Listing>)repository.GetListingByPriceAscending();
        }

        //Viser Listings filteret efter søgeord:

        //Viser Aktive listings for en specifik bruger:

        public IEnumerable<Listing> GetActiveListingsByUser(ObjectId userid)
        {
            return (IEnumerable<Listing>)repository.GetActiveListingsByUser(userid);
        }
    }
}
