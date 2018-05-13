using ConsoleApplication1.server;
using ConsoleApplication1.server.PlaneModels;

namespace ConsoleApplication1.DataBase.Repositories
{
    public class UserRepository
    {
        private AnimalRepository animalRepository = new AnimalRepository();
        
        public User getUserById(int id)
        {
            foreach (User user in DB.users)
            {
                if (user.ID == id)
                    return user;
            }

            return null;
        }

        public User createUser(User user)
        {
            DB.createUser(user);
            return user;
        }

        public User setAnimalOnUser(int id, Animal animal)
        {
            User oldUser = findOneByAnimal(animal);
            if(oldUser != null)
                oldUser.removeAnimal(animal);
            
            User user = getUserById(id);
            if (user != null)
            {
                user.addAnimal(animalRepository.getById(animal.ID));
                return user;
            }

            return null;
        }

        public User[] getUsers()
        {
            return (User[]) DB.users.ToArray(typeof(User));
        }

        public User findOneByAnimal(Animal animal)
        {
            foreach (User user in DB.users)
            {
                if (user.isAppointed(animal))
                    return user;
            }

            return null;
        }
    }
}