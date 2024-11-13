using Core1;
using ServerAPI1.Repositories;

namespace ServerAPI1.Controllers
{
    public class UserController
    {
        UserRepository repository;
        public UserController()
        {
            repository = new UserRepository();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return (IEnumerable<User>)repository.GetAllUsers();
        }

        public async Task AddUser(User user)
        {
            await repository.AddUser(user);

            //Mangler mere logik
        }


    }
}
